import axios, { AxiosResponse } from "axios";

let isInterceptorSetup = false;

export const setupErrorHandlingInterceptor = () => {
    if(!isInterceptorSetup){
        axios.interceptors.response.use(
            (response:AxiosResponse) => response,
            (error) => {
                if(error.response){
                    const statusCode = error.response.statusCode;
                    const data = error.resposne.data;

                    switch(statusCode){
                        case 400:
                            if(data.errors){
                                const modalStateErrors = [];
                                for (const item of data.errors){
                                    const property = item.property;
                                    const errorMessage = item.errorMessage;

                                    if(property && errorMessage){
                                        modalStateErrors.push({property, errorMessage});
                                    }
                                }
                                console.log(modalStateErrors);
                            }
                            break;
                        case 401:
                            console.log("Unauthorized");
                            break;
                        case 403:
                            console.log("Forbidden");
                            break;
                        case 404:
                            console.log('Not found');
                            break;
                        default:
                            console.log('Generic Error')            
                    }
                }
                return Promise.reject(error);
            }
        )
        isInterceptorSetup = true;
    }
}