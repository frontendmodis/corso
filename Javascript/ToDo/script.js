(function(){
"use strict";

init();

function init(){
    load();

    var myForm = document.getElementById('myForm');
    myForm.addEventListener('submit', myFormSubmitted);

    var myReset = document.getElementById('myReset');
    myReset.addEventListener('click', myResetClicked);
    
}

function myFormSubmitted(e){
    e.preventDefault();

    var input = document.getElementById('todo');
    var li = document.createElement('li');
    li.innerHTML = input.value;
    li.setAttribute('draggable', 'true');
    addLiListener(li);  

    var myList = document.getElementById('myList');
    myList.appendChild(li);
    save();

    input.value = '';
}

function myResetClicked(e){
    var fatti = document.getElementsByClassName('done');
    var myList = document.getElementById('myList');

    for(var i = fatti.length - 1; i >= 0; i--){
        myList.removeChild(fatti[i]);
    } 
    save();
}

function liClicked(){
    if(this.className == 'done'){
        this.className = '';
    } else {
        this.className = 'done';
    }
    save();
}

function save(){
    var myList = document.getElementById('myList');
    localStorage.setItem('todo', myList.innerHTML);
}

function load(){
    var todos = localStorage.getItem('todo');
    var myList = document.getElementById('myList');
    myList.innerHTML = todos;

    var listItem = myList.childNodes;
    for(var i = 0; i < listItem.length; i++){
            addLiListener(listItem[i]);                     
    }
}

function addLiListener(li){
    li.addEventListener('click', liClicked);
    li.addEventListener('dragstart', drag);
    li.addEventListener('drop', drop);
    li.addEventListener('dragover', dragOver);                                     
}            

function getLiArray()
{
    var nodeList = [];
    var nodeCollection = document.getElementsByTagName('li');
    var length = nodeCollection.length;
    var i;

    for(i = 0; i < length; i++){
        nodeList.push(nodeCollection[i]);
    }
    
    return nodeList;

    // Oppure più brevemente ma meno chiaramente:
    //return Array.prototype.slice.call(document.getElementsByTagName('li'));
}

function drag(e){
    var nodeList = getLiArray();
    var index = nodeList.indexOf(e.target);        
    e.dataTransfer.setData("text/plain", index);
}

function drop(e){
    e.preventDefault();
    var nodeList = getLiArray();                
    var ixO = parseInt(e.dataTransfer.getData("text"));
    var origin = nodeList[ixO];
    var destination = e.target;

    var destinationContent = destination.innerHTML;
    var destinationClass = destination.className;

    destination.innerHTML = origin.innerHTML;
    destination.className = origin.className;
    origin.innerHTML = destinationContent;
    origin.className = destinationClass;
    
    save();
}

function dragOver(e){
    e.preventDefault();
}

})();