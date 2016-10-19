$(function(){
    $('#myList').on({
        "DOMAttrModified":salva,
        "DOMCharacterDataModified":salva,
        "DOMNodeInserted":salva,
        "DOMNodeRemoved":salva,
        "DOMSubtreeModified":salva
    });

    function salva(){
        localStorage.setItem('todo', $('#myList').html());     
    }
});