export const RequestHttp = async (urlSegment: string, query: string, variables = null) => {

    const response = await fetch(urlSegment, {        
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ query: query, variables: { request: variables } })
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
