import { makeAutoObservable } from "mobx";
import { idText } from "typescript";
import agent from "../API/agent";
import { CityDto } from "../models/cityDto";
import { EventCategoryNavDto } from "../models/eventCategoryNavDto";
import { EventFilterPageDto } from "../models/eventFilterPageDto";
import { EventSubCategoryNavDto } from "../models/eventSubCategoryNavDto";
import { QueryParamsFilter } from "../models/queryParamsFilter";

export default class CategoryPageStore {
    constructor() {
        makeAutoObservable(this)
    }

    events: EventFilterPageDto[] = [];
    setEvents = (val: EventFilterPageDto[]) => this.events = val;

    categories: EventCategoryNavDto[] = []
    setCategories = (val: EventCategoryNavDto[]) => this.categories = val;

    selectedCategoryId: number | undefined
    setSelectedCategoryId = (val: number | undefined) => this.selectedCategoryId = val;

    selectedCategory: EventCategoryNavDto | undefined
    setSelectedCategory = (id: number) => {
        const selectedCategory = this.categories.find(x => x.id === id);
        this.pagingParams.categoryId = id;
        this.selectedCategory = selectedCategory;
    }

    selectedSubcategory: EventSubCategoryNavDto | undefined = undefined
    setSelectedSubcategory = (id: number) => {
        const selectedSubCategory = this.selectedCategory?.subCategories.find(x => x.id === id);
        this.pagingParams.subCategoryId = id;
        this.selectedSubcategory = selectedSubCategory;
    }

    cities: CityDto[] = [];
    setCities = (val: CityDto[]) => this.cities = val;

    selectedCity: CityDto | undefined = undefined;
    setSelectedCity = (id: number) => {
        const selectedCity = this.cities.find(x => x.id === id);
        this.pagingParams.cityId = id;
        this.selectedCity = selectedCity;
    }

    pagingParams: QueryParamsFilter = new QueryParamsFilter(undefined, undefined, undefined);
    setPagingParams = (params: QueryParamsFilter) => this.pagingParams = params;

    getAxiosParams = () => {
        const params = new URLSearchParams();

        if (this.pagingParams.categoryId) {
            params.append('categoryId', this.pagingParams.categoryId.toString())
        }
        if (this.pagingParams.subCategoryId) {
            params.append('subCategoryId', this.pagingParams.subCategoryId.toString())
        }
        if (this.pagingParams.cityId) {
            params.append('cityId', this.pagingParams.cityId.toString())
        }  

        return params;
    }

    loadEvents = () => {
        agent.Events.categorySearch(this.getAxiosParams())
            .then(response => {
                this.setEvents(response);
            })
    }


}