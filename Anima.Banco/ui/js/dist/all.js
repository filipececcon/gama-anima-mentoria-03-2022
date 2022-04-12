const app = angular.module("app", []);
(() => {

    app.controller('CustomerController', ($scope, $http, config) => {

        let me = $scope

        me.name = ""
        me.email = ""

        me.route = config.baseUrl + "/customer"

        me.send = async () => {
            
            var customer = { name:me.name , email : me.email }

            try {
                var response = await $http.post(me.route, null, customer)              
                
            } catch (error) {
                console.log(error)
            }

        }

        me.load = async () =>{

            try {
                var response = await $http.get(me.route)

                me.list = response.data

                console.log(me.list)
                
            } catch (error) {
                console.log(error)
            }

        }

    })
})();
(() => {
	
	app.value('config', {
		baseUrl: 'http://localhost:5000/api'
	})
	
})()