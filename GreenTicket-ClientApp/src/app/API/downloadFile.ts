import { AxiosResponse } from "axios";

export function downloadFile(response: AxiosResponse<any, any>, fileName: string) {
    const url = window.URL.createObjectURL(new Blob([response.data]));
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', fileName);
    document.body.appendChild(link);
    link.click();
}