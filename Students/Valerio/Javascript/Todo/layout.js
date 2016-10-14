(function(){
    window.addEventListener('scroll',handleScrool);

    function handleScrool(e){
        var header = document.getElementById('header');
        var form = document.getElementById('myForm');
        var list = document.getElementById('myList');

        if(document.body.scrollTop > header.offsetHeight){
            form.className = 'fixed';
            header.style.marginTop = form.offsetHeight.toString() + 'px';
            form.style.width = header.offsetWidth.toString() + 'px';

        } else {
            form.className = '';
            header.style.marginTop = '0';
            delete form.style.width;
        }     
    }
})();