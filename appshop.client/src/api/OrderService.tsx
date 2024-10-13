import { RequestHttp } from "./RequestHttp";
import { appSettings } from '../settings/AppSettings';

const urlBase = appSettings.apiUrl.orderUrl;

export const addOrder = async (order) => {
    const urlSegment = `${urlBase}/order/addOrder`;
    const response = await RequestHttp(urlSegment, false, order);
    return response;
}