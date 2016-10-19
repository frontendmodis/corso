(function(){
    "use strict";

    var app = angular.module('todoApp', ['filearts.dragDrop']);

    app.controller('InputController', InputController);
    app.controller('ListaController', ListaController);

    InputController.$inject = ['$rootScope'];

    function InputController($rootScope){
        var vm = this;
        vm.testo = '';
        vm.aggiungi = aggiungi;
        vm.reset = reset;

        function aggiungi(){
            var todo = ToDoFactory(vm.testo, false);
            $rootScope.$broadcast('nuovoTodo', todo);
            vm.testo = '';
        }

        function reset(){
            $rootScope.$broadcast('richiestoReset');
        }
    }

    ListaController.$inject = ['$rootScope', '$filter', '$window'];

    function ListaController($rootScope, $filter, $window){
        var vm = this;
        vm.todoes = [];
        vm.toggle = toggle;

        $rootScope.$on('nuovoTodo', nuovoTodo);
        $rootScope.$on('richiestoReset', richiestoReset);

        load();

        function toggle(todo){
            todo.done = !todo.done;
            save();    
        }

        function nuovoTodo(e, todo){
            vm.todoes.push(todo);
            save();
        }

        function richiestoReset(){
            vm.todoes = $filter('filter')(vm.todoes, { done: false });
            save();
        }        

        function load() {
            var todoes = $window.localStorage.getItem('todoes');

            if(todoes){
                vm.todoes = JSON.parse(todoes);
            }
        }

        function save() {
            $window.localStorage.setItem('todoes', JSON.stringify(vm.todoes));
        }
    }

    function ToDoFactory(testo, done){
        return {
            testo: testo,
            done: done
        };
    }

})();