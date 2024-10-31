import { RequestHttp } from "./RequestHttp";
import { appSettings } from '../settings/AppSettings';

const urlBase = appSettings.apiUrl.catalogUrl;

//export const addOrder = async (order) => {
//    const urlSegment = `${urlBase}/order/addOrder`;
//    const response = await RequestHttp(urlSegment, false, order);
//    return response;
//}

export const addOrder = async (order) => {
    try {
        const query = `mutation ($request:OrderDtoInput!) {
                addOrder(request:$request) {
                    result,
                    statusMessage
                }
            }`;
        const response = await RequestHttp(urlBase, query, order);
        return response;
    }
    catch (error) {
        console.error('Error adding order is: ', error);
        throw error;
    }
}