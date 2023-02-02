window.ready = () => {
    /**
     * On scroll
     */
    window.addEventListener('scroll', function () {
        if (window.scrollY > 0) {
            $('nav').addClass('scrolled');
        }
        else {
            $('nav').removeClass('scrolled');
        }
    })
}