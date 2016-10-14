(function(){
    
    init();

    function init(){
        window.addEventListener('scroll', pageScrolling);
    }

    function pageScrolling(e){

        var main = document.getElementsByTagName('main')[0];
 
        if(window.scrollY >= 55){
            if(main.className !== 'down'){
                main.className = 'down';
            }
        } else {
            if(main.className !== ''){
                main.className = '';
            }            
        }
    }
})();