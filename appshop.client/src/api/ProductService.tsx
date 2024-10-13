import { RequestHttp } from "./RequestHttp";
import { appSettings } from '../settings/AppSettings';

const urlBase = appSettings.apiUrl.catalogUrl;

export const requestProducts = async (pageNumber: number, pageSize: number) => {
    try {
        const query = `{
            products(pageNumber:${pageNumber},pageSize:${pageSize}){
              result{
                totalPages,
                currentPage,
                totalProducts
                products{
                    productId,
                    productName,
                    description,
                    stock,
                    price,
                    image,
                    quantity
                }
              }
            }
          }`;
        const response = await RequestHttp(urlBase, true, query);
        return response;
    }
    catch (error) {
        console.error('Error fetching Products is: ', error);
        throw error;
    }
}

export const requestProductById = async (id: number) => {
    try {
        const query = `{
          productById(id:${id}) {
             result{
              stock
             }
          }
        }`;
        const response = await RequestHttp(urlBase, true, query);
        return response;
    }
    catch (error) {
        console.error('Error fetching Product by Id is: ', error);
        throw error;
    }
}