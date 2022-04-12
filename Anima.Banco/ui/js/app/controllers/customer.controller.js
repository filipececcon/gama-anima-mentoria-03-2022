(() => {

    app.controller('CustomerController', CustomerController)


    CustomerController.$inject('httpService')

    CustomerController = ($scope, httpService) => {
        
        var me = $scope

        me.name = ""
        me.email = ""

        me.send = () => {
            console.log( { name:me.name , email : me.email })            
        }

        me.load = async () =>{

            me.list = await httpService.get("/customer")

            console.log(me.list)
        }
    }
})()