(()=> {

    app.service("httpService", ($http, config) => {

        get = (path) => {
            return new Promise(async (resolve, reject) => {
                try{
                    var response = await $http.get(config.baseUrl + path)
                    resolve(response.data)
                }
                catch(err){
                    reject(err)
                }
            })            
        }
    })
})()