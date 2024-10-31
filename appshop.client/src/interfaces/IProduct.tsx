interface IProduct {
    productId?: number,
    productName: string,
    productCode: string,
    description: string,
    price?: number,
    stock?: number,
    quantity?: number
}

export default IProduct;