(function(){
    "use strict";

    (function init(){
        load();

        var myForm = document.getElementById('myForm');
        myForm.addEventListener('submit', myFormSubmitted);
        
        var myReset = document.getElementById('myReset');
        myReset.addEventListener("click", myResetClicked);
    })();

    function myFormSubmitted(e){
        e.preventDefault();
        var text = document.getElementById('myForm__text');
        if(!text.value){
            return;
        }
        var toDo = createToDo(text.value);
        var myList = document.getElementById("myList");
        myList.appendChild(toDo);        
        text.value = '';
        save()
    }

    function myResetClicked(e){
        var fatti = document.getElementsByClassName('done');
        var myList = document.getElementById('myList');

        while(fatti.length > 0){
            myList.removeChild(fatti[0]);
        }
        save()
    }

    function createToDo(text){
        var li = document.createElement('li');
        li.innerHTML = text;
        addEvent(li);
        return li;
    }

    function addEvent(node){
        node.addEventListener('click', handleToDoClick);
        
        node.setAttribute('draggable', 'true');
        node.addEventListener('dragstart', handleDragStart);
        node.addEventListener('dragover', handleDragOver);
        node.addEventListener('drop', handleDrop);
    }

    function handleToDoClick(){
        if(this.className === 'done'){
            this.className = '';
        } else {
            this.className = 'done';
        }
        save()        
    }

    function handleDragStart(e){
        var myList = document.getElementById('myList');
        var nodeList = Array.prototype.slice.call(myList.childNodes);
        e.dataTransfer.setData('text/plain', nodeList.indexOf(e.target));
    }

    function handleDragOver(e){
        e.preventDefault();
    }

    function handleDrop(e){
        e.preventDefault();
        var myList = document.getElementById('myList');
        var nodeList = Array.prototype.slice.call(myList.childNodes);

        var origin = nodeList[parseInt(e.dataTransfer.getData('text/plain'))] 
        var destination = e.target;

        if(origin != destination){
            myList.insertBefore(origin, destination);
        }
        save();
    }

    function save() {
        var myList = document.getElementById('myList');
        localStorage.setItem('ToDoList', myList.innerHTML);
    }

    function load() {
        var myList = document.getElementById('myList');
        myList.innerHTML = localStorage.getItem('ToDoList');
        var myToDoes = myList.childNodes;
        for (var i = 0; i < myToDoes.length; i++){
            addEvent(myToDoes[i]);
        }
    }
})();