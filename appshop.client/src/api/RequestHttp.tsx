export const RequestHttp = async (urlSegment: string, query: boolean, request = null) => {

    const response = await fetch(urlSegment, {        
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(
          query ? { query: request } : request
        )
    })
    if (response.ok) {
        try {
            const result = await response.json()
            return {
                isOk: true,
                result: result.data
            }
        }
        catch (error) {
            return {
                isOk: false,
                message: error
            }
        }
    }
    else {
        return {
            isOk: false,
            message: await response.text()
        }
    }
}
