'use strict';

$(window).on('load', function(){
    // $('.preloader').fadeOut(1000); // set duration in brackets
    init();
});



$(document).ready(function() {
  owlCarousel();
  isotope();
  magnificPopup();
});


/* --- initialize functions on window load here -------------- */

function init() {
  headerShrink();
  isotopeMenuFilters();
}



/* --- headerShrink ------------- */

function headerShrink() {
    window.addEventListener('scroll', function(e){
        var distanceY = window.pageYOffset || document.documentElement.scrollTop,
            shrinkOn = 90,
            header = document.querySelector(".tp--header-shrink");
        if (distanceY > shrinkOn) {
            classie.add(header,"shrink");
        } else {
            if (classie.has(header,"shrink")) {
                classie.remove(header,"shrink");
            }
        }
    });
}



/* --- Dropdown Menu Javascript ------------ */

jQuery(document).ready(function($){
  function morphDropdown( element ) {
    this.element = element;
    this.mainNavigation = this.element.find('.main-nav');
    this.mainNavigationItems = this.mainNavigation.find('.has-dropdown');
    this.dropdownList = this.element.find('.dropdown-list');
    this.dropdownWrappers = this.dropdownList.find('.dropdown');
    this.dropdownItems = this.dropdownList.find('.content');
    this.dropdownBg = this.dropdownList.find('.bg-layer');
    this.mq = this.checkMq();
    this.bindEvents();
  }

  morphDropdown.prototype.checkMq = function() {
    //check screen size
    var self = this;
    return window.getComputedStyle(self.element.get(0), '::before').getPropertyValue('content').replace(/'/g, "").replace(/"/g, "").split(', ');
  };

  morphDropdown.prototype.bindEvents = function() {
    var self = this;
    //hover over an item in the main navigation
    this.mainNavigationItems.mouseenter(function(event){
      //hover over one of the nav items -> show dropdown
      self.showDropdown($(this));
    }).mouseleave(function(){
      setTimeout(function(){
        //if not hovering over a nav item or a dropdown -> hide dropdown
        if( self.mainNavigation.find('.has-dropdown:hover').length == 0 && self.element.find('.dropdown-list:hover').length == 0 ) self.hideDropdown();
      }, 50);
    });
    
    //hover over the dropdown
    this.dropdownList.mouseleave(function(){
      setTimeout(function(){
        //if not hovering over a dropdown or a nav item -> hide dropdown
        (self.mainNavigation.find('.has-dropdown:hover').length == 0 && self.element.find('.dropdown-list:hover').length == 0 ) && self.hideDropdown();
      }, 50);
    });

    //click on an item in the main navigation -> open a dropdown on a touch device
    this.mainNavigationItems.on('touchstart', function(event){
      var selectedDropdown = self.dropdownList.find('#'+$(this).data('content'));
      if( !self.element.hasClass('is-dropdown-visible') || !selectedDropdown.hasClass('active') ) {
        event.preventDefault();
        self.showDropdown($(this));
      }
    });

    //on small screens, open navigation clicking on the menu icon
    this.element.on('click', '.nav-trigger', function(event){
      event.preventDefault();
      self.element.toggleClass('nav-open');
    });
  };

  morphDropdown.prototype.showDropdown = function(item) {
    this.mq = this.checkMq();
    if( this.mq == 'desktop') {
      var self = this;
      var selectedDropdown = this.dropdownList.find('#'+item.data('content')),
        selectedDropdownHeight = selectedDropdown.innerHeight(),
        selectedDropdownWidth = selectedDropdown.children('.content').innerWidth(),
        selectedDropdownLeft = item.offset().left + item.innerWidth()/2 - selectedDropdownWidth/2;

      //update dropdown position and size
      this.updateDropdown(selectedDropdown, parseInt(selectedDropdownHeight), selectedDropdownWidth, parseInt(selectedDropdownLeft));
      //add active class to the proper dropdown item
      this.element.find('.active').removeClass('active');
      selectedDropdown.addClass('active').removeClass('move-left move-right').prevAll().addClass('move-left').end().nextAll().addClass('move-right');
      item.addClass('active');
      //show the dropdown wrapper if not visible yet
      if( !this.element.hasClass('is-dropdown-visible') ) {
        setTimeout(function(){
          self.element.addClass('is-dropdown-visible');
        }, 10);
      }
    }
  };

  morphDropdown.prototype.updateDropdown = function(dropdownItem, height, width, left) {
    this.dropdownList.css({
        '-moz-transform': 'translateX(' + left + 'px)',
        '-webkit-transform': 'translateX(' + left + 'px)',
      '-ms-transform': 'translateX(' + left + 'px)',
      '-o-transform': 'translateX(' + left + 'px)',
      'transform': 'translateX(' + left + 'px)',
      'width': width+'px',
      'height': height+'px'
    });

    this.dropdownBg.css({
      '-moz-transform': 'scaleX(' + width + ') scaleY(' + height + ')',
        '-webkit-transform': 'scaleX(' + width + ') scaleY(' + height + ')',
      '-ms-transform': 'scaleX(' + width + ') scaleY(' + height + ')',
      '-o-transform': 'scaleX(' + width + ') scaleY(' + height + ')',
      'transform': 'scaleX(' + width + ') scaleY(' + height + ')'
    });
  };

  morphDropdown.prototype.hideDropdown = function() {
    this.mq = this.checkMq();
    if( this.mq == 'desktop') {
      this.element.removeClass('is-dropdown-visible').find('.active').removeClass('active').end().find('.move-left').removeClass('move-left').end().find('.move-right').removeClass('move-right');
    }
  };

  morphDropdown.prototype.resetDropdown = function() {
    this.mq = this.checkMq();
    if( this.mq == 'mobile') {
      this.dropdownList.removeAttr('style');
    }
  };

  var morphDropdowns = [];
  if( $('.tp--header').length > 0 ) {
    $('.tp--header').each(function(){
      //create a morphDropdown object for each .cd-morph-dropdown
      morphDropdowns.push(new morphDropdown($(this)));
    });

    var resizing = false;

    //on resize, reset dropdown style property
    updateDropdownPosition();
    $(window).on('resize', function(){
      if( !resizing ) {
        resizing =  true;
        (!window.requestAnimationFrame) ? setTimeout(updateDropdownPosition, 300) : window.requestAnimationFrame(updateDropdownPosition);
      }
    });

    function updateDropdownPosition() {
      morphDropdowns.forEach(function(element){
        element.resetDropdown();
      });

      resizing = false;
    };
  }
});



/* --- owlCarousel ------------- */

function owlCarousel() {

  var oc = $('.owl-carousel');
  var ocOptions = oc.data('carousel-options');
  var defaults = {
    loop:            true,
    nav:             false,
    autoplay:        true,
  }
  
  oc.owlCarousel( $.extend( defaults, ocOptions) );


  $(".tp--owl-carousel-single").owlCarousel({
    lazyLoad: true,
    lazyEffect: "fade",
    items: 1,
    loop: true,
    margin: 0,
    nav: true,
    dots: false,
    autoHeight : false,
    mouseDrag: false,
    touchDrag: false,
    navText : ['<i class="icon-arrow-left icons"></i>','<i class="icon-arrow-right icons"></i>']
  });

  $(".tp--owl-carousel-single-auto").owlCarousel({
    lazyLoad: true,
    lazyEffect: "fade",
    items: 1,
    loop: true,
    margin: 0,
    nav: false,
    dots: true,
    autoHeight : false,
    mouseDrag: false,
    touchDrag: false,
    autoplay: true
  });

  $(".tp--slider-multiple").owlCarousel({
      lazyLoad : true,
      items: 4,
      theme: "owl-theme-main",
      nav: false,
      responsive:{
        0: {
          items: 1
        },
        600: {
          items: 2
        },
        700: {
          items: 3
        },
        1300: {
          items: 4
        }
    }
    }); 
}



/* --- Isotope ------------------- */

function isotope() {


 var $container = $('.tp--portfolio .tp--portfolio-grid');

 // init
 // $container.imagesLoaded( function(){
   
 // });
 $container.isotope({
   // options
   itemSelector: '.tp--portfolio-item',
   layoutMode: 'fitRows'
 });

 // filter items on button click
 $('.tp--portfolio-filters').on( 'click', 'button', function( event ) {
   var filterValue = $(this).attr('data-filter-value');
   $container.isotope({ filter: filterValue });
   $('#filters button').removeClass('active');
   $(this).addClass('active');
 });

}


/* --- Isotope Filter Menu ------------- */

function isotopeMenuFilters() {
  [].slice.call(document.querySelectorAll('.tp--portfolio-filters')).forEach(function(menu) {
    var menuItems = menu.querySelectorAll('.tp--menu-link'),
      setCurrent = function(ev) {
        ev.preventDefault();

        var item = ev.target.parentNode; // li

        // return if already current
        if (classie.has(item, 'tp--menu-item--current')) {
          return false;
        }
        // remove current
        classie.remove(menu.querySelector('.tp--menu-item--current'), 'tp--menu-item--current');
        // set current
        classie.add(item, 'tp--menu-item--current');
      };

    [].slice.call(menuItems).forEach(function(el) {
      el.addEventListener('click', setCurrent);
    });
  });

  [].slice.call(document.querySelectorAll('.link-copy')).forEach(function(link) {
    link.setAttribute('data-clipboard-text', location.protocol + '//' + location.host + location.pathname + '#' + link.parentNode.id);
    new Clipboard(link);
    link.addEventListener('click', function() {
      classie.add(link, 'link-copy--animate');
      setTimeout(function() {
        classie.remove(link, 'link-copy--animate');
      }, 300);
    });
  });
}





/* --- magnific popup ------------------- */

function magnificPopup() {

  // Gallery
  $('.popup-gallery').magnificPopup({
    type: 'image',
    tLoading: 'Loading image #%curr%...',
    mainClass: 'mfp-fade',
    disableOn: 700,
    removalDelay: 160,
    gallery: {
      enabled: true,
      navigateByImgClick: true,
      preload: [0,1] // Will preload 0 - before current, and 1 after the current image
    },
    image: {
      tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
    },
    callbacks: {
      close: function() {
        $('.portfolio-item figure figcaption').removeClass('active');
        $('.portfolio-item figure .info').removeClass('active');
      }
    }
  });

  $('.portfolio-item figcaption a.preview').click(function(){
    $(this).parent().addClass('active');
    $(this).parent().siblings('.info').addClass('active');
  });

  // Zoom Gallery

  $('.zoom-modal').magnificPopup({
    type: 'image',
    mainClass: 'mfp-with-zoom', // this class is for CSS animation below

    zoom: {
      enabled: true, // By default it's false, so don't forget to enable it

      duration: 300, // duration of the effect, in milliseconds
      easing: 'ease-in-out', // CSS transition easing function 

      // The "opener" function should return the element from which popup will be zoomed in
      // and to which popup will be scaled down
      // By defailt it looks for an image tag:
      opener: function(openerElement) {
        // openerElement is the element on which popup was initialized, in this case its <a> tag
        // you don't need to add "opener" option if this code matches your needs, it's defailt one.
        return openerElement.is('i') ? openerElement : openerElement.find('i');
      }
    }

  });

  $('.popup-modal').magnificPopup({
    type: 'inline',
    // Delay in milliseconds before popup is removed
    removalDelay: 300,

    // Class that is added to popup wrapper and background
    // make it unique to apply your CSS animations just to this exact popup
    mainClass: 'mfp-fade'
  });
}