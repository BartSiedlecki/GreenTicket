import axios, { AxiosError, AxiosResponse } from 'axios';
import i18next from 'i18next';
import { toast } from 'react-toastify';
import { baseApiUrl } from '../../config';
import customHistory from '../..';
import createAuthRefreshInterceptor from 'axios-auth-refresh';
import { EventCarouselDto } from '../models/eventCarouselDto';
import { EventCategoryNavDto } from '../models/eventCategoryNavDto';
import { EventNavigationSearchResultItemDto } from '../models/eventNavigationSearchResultItemDto';
import { EventCardDto } from '../models/eventCardDto';
import { CardCategory } from '../models/cardCategory';
import { EventPageDto } from '../models/eventPageDto';
import { SectionDto } from '../models/sectionDto';
import { CityDto } from '../models/cityDto';
import { EventFilterPageDto } from '../models/eventFilterPageDto';

axios.defaults.baseURL = baseApiUrl;
axios.defaults.withCredentials = true;

const responseBody = <T>(response: AxiosResponse<T>) => response.data;


const refreshAuthLogic = (failedRequest: any) =>
    axios.get(`${baseApiUrl}/account/refresh`).then((tokenRefreshResponse) => {
        failedRequest.response.config.withCredentials = true;
        return Promise.resolve().then();
    }).catch((err: any) => {

        const originalRequestURL: string = failedRequest.request.responseURL;

        if (!(originalRequestURL.includes('/api/account'))) {
            if (Array.isArray(err)) {
                if (err[0] === 'Refresh token expired') {
                    const message401 = i18next.t("autoLogoutInfo").toString()
                    toast.error(message401);
                    customHistory.push('/logout');
                }
            }
        }
    });

axios.interceptors.request.use(config => {
    config.withCredentials = true;
    return config;
})

axios.interceptors.response.use(
    response => {
        const pagination = response.headers['pagination'];
        if (pagination) {
            //response.data = new PaginatedResult(response.data, JSON.parse(pagination));
            //return response as AxiosResponse<PaginatedResult<any>>;
        }
        return response;
    },
    (error: any) => {
        const { data, status } = error.response!;
        let errors = []
        console.log(error);

        switch (status) {
            case 400:
                if (data.errors) {
                    const modalStateErrors = [];
                    for (const key in data.errors) {
                        if (data.errors[key]) {
                            modalStateErrors.push(data.errors[key])
                        }
                    }
                    throw modalStateErrors.flat();
                }
                if (data) {
                    if (typeof data === 'string' || data instanceof String) {
                        const modalStateErrors = [];
                        modalStateErrors.push(data);
                        const message403 = i18next.t(data.toString()).toString()
                        toast.error(message403);
                        throw modalStateErrors.flat();
                    }
                }
                break;
            case 401:
            case 403:
                if (data.errors) {
                    const modalStateErrors = [];
                    for (const key in data.errors) {
                        if (data.errors[key]) {
                            modalStateErrors.push(data.errors[key])
                        }
                    }
                    throw modalStateErrors.flat();
                }
                if (data) {
                    if (typeof data === 'string' || data instanceof String) {
                        const modalStateErrors = [];
                        modalStateErrors.push(data);
                        throw modalStateErrors.flat();
                    }
                }
                break;
            case 404:
                const message404 = i18next.t("apiErrorNotFoundInfo").toString()
                toast.error(message404);
                errors.push(message404);
                throw errors.flat();
            case 409:
                const message409 = i18next.t("apiErrorConflictInfo").toString()
                toast.error(message409);
                errors.push(message409);
                throw errors.flat();
            case 415:
                const message415 = i18next.t("apiErrorUnsupportedMediaType").toString()
                toast.error(message415);
                errors.push(message415);
                throw errors.flat();
            case 500:
                const message500 = i18next.t("apiErrorServerErrorInfo").toString()
                toast.error(message500);
                errors.push(message500);
                throw errors.flat();
            default:
                const message = i18next.t("apiErrorUnexpected").toString()
                toast.error(message);
                errors.push(message);
                throw errors.flat();
        }
        return Promise.reject(error);
    })

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    getWithParams: <T>(url: string, params: URLSearchParams) => axios.get<T>(url, { params }).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    putWithoutBody: <T>(url: string) => axios.put<T>(url).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    patch: <T>(url: string, body: {}) => axios.patch<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
    getFile: <T>(url: string, body: {}) => axios({ url: url, method: 'POST', responseType: 'blob', data: body }),
    getFileById: <T>(url: string) => axios({ url: url, method: 'GET', responseType: 'blob' }),
    getFileWithParams: <T>(url: string, params: {}) => axios({ url: url, method: 'GET', responseType: 'blob', params: params }),
}

createAuthRefreshInterceptor(axios, refreshAuthLogic);


const Addresses = {
    getNavigation: () => requests.get<CityDto[]>("/address/city/navigation")
}

const Categories = {
    getNavigation: () => requests.get<EventCategoryNavDto[]>("/category/navigation")
}

const Events = {
    getEventPageMode: (id: number) => requests.get<EventPageDto>(`/event/${id}`),
    navigationSearch: (phrase: string) => requests.get<EventNavigationSearchResultItemDto[]>(`/event/navigation/search?phrase=${phrase}`),
    categorySearch: (params: URLSearchParams) => requests.getWithParams<EventFilterPageDto[]>(`/event`, params ),
    carousels: (qty: number) => requests.get<EventCarouselDto[]>(`/event/carousel?qty=${qty}`),
    eventCards: (category: CardCategory, qty: number) => requests.get<EventCardDto[]>(`/event/card/newest?category=${category}&qty=${qty}`),
}

const ImagePath = (fileName: string) => `${baseApiUrl}/image?fileName=${fileName}`;

const Seats = {
    reserve: (eventId: number, sectionId: number, seatId: string, sesstionId: string) => requests.putWithoutBody(`/event/${eventId}/section/${sectionId}/seat/${seatId}/reservation?session=${sesstionId}`),
    cancelReservationSeat: (eventId: number, sectionId: number, seatId: string, sesstionId: string) => requests.putWithoutBody(`/event/${eventId}/section/${sectionId}/seat/${seatId}/reservation/cancel?session=${sesstionId}`)
}

const Sections = {
    getPreview: (eventId: number, sectionId: number, sesstionId: string) => requests.get<SectionDto>(`/event/${eventId}/section/${sectionId}?session=${sesstionId}`)
}

const agent = {
    Addresses,
    Categories,
    Events,
    ImagePath,
    Seats,
    Sections
}

export default agent;

