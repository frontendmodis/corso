$(function(){
"use strict";

init();

function init(){
    load();

    $('#myForm').submit(myFormSubmitted);
    $('#myReset').click(function(e){    
        $('.done').remove();
    });

    if (Modernizr.mutationobserver) {
        MutationObserver = window.MutationObserver || window.WebKitMutationObserver;
        var obs = new MutationObserver(function(mutation, observer){
            localStorage.setItem('todo', $('#myList').html());
        });

        obs.observe($('#myList')[0], {
            subtree: true,
            attributes: true,
            childList: true
        });
    } else {
        $.getScript('mutationevents.js');
    }
}

function myFormSubmitted(e){
    e.preventDefault();

    var $input = $('#todo');
    var $li = $('<li></li>')
        .attr('draggable', 'true')
        .html($input.val());

    addLiListener($li);  

    $('#myList').append($li);

    $input.val('');
}

function load(){    
    var todos = localStorage.getItem('todo');
    $('#myList').html(todos);
    $('#myList').children().each(function(i, li){
        addLiListener($(li));
    });
}

function addLiListener($li){
    $li.on({
        'click': function(){
            $(this).toggleClass('done');
       },
        'dragstart': function(e){
            var index = $('li').index(e.target);        
            e.originalEvent.dataTransfer.setData("text/plain", index);
        },
        'drop': drop,
        'dragover': function(e){
            e.preventDefault();
        }
    });
}            

function drop(e){
    e.preventDefault();
    var ixO = parseInt(e.originalEvent.dataTransfer.getData("text"));
    var $origin = $('li').eq(ixO);
    var destination = e.target;

    var destinationContent = destination.innerHTML;
    var destinationClass = destination.className;

    destination.innerHTML = $origin.html();
    destination.className = $origin.attr('class');
    $origin.html(destinationContent);
    $origin.attr('class', destinationClass);    
}
});