// page init
$(document).ready(function() {

	"use strict";

	function collapseMenu(){
		jQuery('.hb-navigation ul li.menu-item-has-children, .hb-navigation ul li.menu-item-has-mega-menu')
		/*.prepend('<span class="hb-dropdowarrow"><i class="fa fa-angle-down"></i></span>')*/;
		jQuery('.hb-navigation ul li.menu-item-has-children, .hb-navigation ul li.menu-item-has-mega-menu ').on('click', function() {
			jQuery(this).toggleClass('hb-open');
			jQuery(this).children('.sub-menu').slideToggle(300);
		});
	}
	collapseMenu();
	/*--------------------------------------
			MEGA MENU						
	--------------------------------------*/
	jQuery(function ($) {
		function hoverIn() {
			var a = jQuery(this);
			var nav = a.closest('.hb-navigation');
			var mega = a.find('.mega-menu');
			var offset = rightSide(nav) - leftSide(a);
			mega.width(Math.min(rightSide(nav), columns(mega)*230));
			mega.css('left', Math.min(0, offset - mega.width()));
		}
		function hoverOut() {}
		function columns(mega) {
			var columns = 0;
			mega.children('.mega-menu-row').each(function () {
				columns = Math.max(columns, jQuery(this).children('.mega-menu-col').length);
			});
			return columns;
		}
		function leftSide(elem) {
			return elem.offset().left;
		}
		function rightSide(elem) {
			return elem.offset().left + elem.width();
		}
		jQuery('.menu-item-has-mega-menu').hover(hoverIn, hoverOut);
	});

	$(function () {
        $(' #gallery .gallary-img ').hoverdir();
    });

    jQuery("#contactForm").validator().on("submit", function (event) {

		"use strict";

		if (event.isDefaultPrevented()) {
			// handle the invalid form...
			formError();
			submitMSG(false, "Please Follow Error Messages and Complete as Required");
		} else {
			// everything looks good!
			event.preventDefault();
			submitForm();
		}
	});

	function submitForm(){
		
		"use strict";

		// Initiate Variables With Form Content
		var work = $("#work").val();
		var number = $("#number").val();
		var name = $("#name").val();

		$.ajax({
			type: "POST",
			url: "php/form-process.php",
			data: "work=" + work + "&number=" + number + "&name=" + name,
			success : function(text){
				if (text == "success"){
					formSuccess();
				} else {
					formError();
					submitMSG(false,text);
				}
			}
		});
	}

	function formSuccess(){
		
		"use strict";

		$("#contactForm")[0].reset();
		submitMSG(true, "Thank you for your submission :)")
	}

	function formError(){
		
		"use strict";

		$("#contactForm").removeClass().addClass('shake animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
			$(this).removeClass();
		});
	}

	function submitMSG(valid, msg){
		
		"use strict";

		if(valid){
			var msgClasses = "success form-message";
		} else {
			var msgClasses = "error form-message";
		}
		$("#msgSubmit").removeClass().addClass(msgClasses).text(msg);
	}

	initCounter();
	// Counter init
	function initCounter() {
		"use strict";

		jQuery('.counter').counterUp({
			delay: 10,
			time: 2000
		});
	}


	$( document ).ready(function() {
		  var hamburger = $('#hamburger-icon');
		  hamburger.click(function() {
		     hamburger.toggleClass('active');
		     return false;
		});
	});

	initAddClass();
	// Add Class  init
	function initAddClass() {
		"use strict";
		
		jQuery('.nav-opener').on( "click", function(e){
			e.preventDefault();
			jQuery("body").toggleClass("nav-active");
		});
		jQuery('.form-opener').on( "click", function(e){
	      e.preventDefault();
	      jQuery("body").toggleClass("form-open");
	    });
	}


	initbackTop();
	// backtop init
	function initbackTop() {
		"use strict";

	    var jQuerybackToTop = jQuery("#back-top");
	    jQuery(window).on('scroll', function() {
	        if (jQuery(this).scrollTop() > 100) {
	            jQuerybackToTop.addClass('active');
	        } else {
	            jQuerybackToTop.removeClass('active');
	        }
	    });
	    jQuerybackToTop.on('click', function(e) {
	        jQuery("html, body").animate({scrollTop: 0}, 900);
	    });
	}


	initSlickSlider();
	// Slick Slider init
	function initSlickSlider() {
		"use strict";

		jQuery('.hero-slide').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 1,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 1000
		});
		jQuery('.banner-slide').slick({
			dots: false,
			speed: 800,
			fade: true,
  			cssEase: 'linear',
			infinite: true,
			slidesToShow: 1,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 2000,
		});
		jQuery('.partners-slide').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 5,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 500,
			responsive: [
				{
			      breakpoint: 1199,
			      settings: {
			        slidesToShow: 4,
			        slidesToScroll: 1,
			      }
			    },
			    {
			      breakpoint: 1023,
			      settings: {
			        slidesToShow: 3,
			        slidesToScroll: 1,
			      }
			    },
			    {
			      breakpoint: 767,
			      settings: {
			        slidesToShow: 2,
			        slidesToScroll: 1
			      }
			    }
		    ]
		});
		jQuery('.testimonial-slide').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 1,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: false,
			arrows: false,
			fade: true,
			autoplaySpeed: 2000
		});
		jQuery('.gallary-slide').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 4,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 1000,
			responsive: [
				{
			      breakpoint: 1199,
			      settings: {
			        slidesToShow: 3,
			        slidesToScroll: 1,
			      }
			    },
			    {
			      breakpoint: 992,
			      settings: {
			        slidesToShow: 2,
			        slidesToScroll: 1,
			      }
			    },
			    {
			      breakpoint: 576,
			      settings: {
			        slidesToShow: 1,
			        slidesToScroll: 1
			      }
			    }
		    ]
		});
		jQuery('.blog-slide').slick({
			dots: true,
			speed: 800,
			infinite: true,
			slidesToShow: 1,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 2000,
		});
		jQuery('.feature-sec').slick({
		    dots: false,
		    speed: 800,
		    infinite: true,
		    slidesToShow: 4,
		    slidesToScroll: 1,
		    adaptiveHeight: true,
		    autoplay: true,
		    arrows: false,
		    autoplaySpeed: 4000,
		    responsive: [
		        {
		        breakpoint: 1199,
			        settings: {
			            slidesToShow: 3,
			            slidesToScroll: 3,
			        }
		        },
		        {
		        breakpoint: 1023,
			        settings: {
			            slidesToShow: 2,
			            slidesToScroll: 1,
			        }
		        },
		        {
		        breakpoint: 767,
			        settings: {
			            slidesToShow: 1,
			            slidesToScroll: 1,
			        }
		        }
		    ]
		});
		jQuery('.service-slide').slick({
			dots: true,
			speed: 800,
			infinite: true,
			slidesToShow: 3,
			slidesToScroll: 1,
			adaptiveHeight: false,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 2000,
			responsive: [
				{ 
			      breakpoint: 1024,
			      settings: {
			        slidesToShow: 2,
			        slidesToScroll: 1,
			      }
			    },
			    {
			      breakpoint: 768,
			      settings: {
			      	arrows:false,
			        slidesToShow: 1,
			        slidesToScroll: 1
			      }
			    }
		    ]
		});
		jQuery('.partner-slider').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 5,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: false,
			autoplaySpeed: 2000,
			responsive: [
				{ 
			      breakpoint: 1024,
			      settings: {
			        slidesToShow: 4,
			        slidesToScroll: 1,
			      }
			    },
			    { 
			      breakpoint: 768,
			      settings: {
			        slidesToShow: 3,
			        slidesToScroll: 1,
			      }
			    },
			    { 
			      breakpoint: 575,
			      settings: {
			        slidesToShow: 2,
			        slidesToScroll: 1,
			      }
			    }
		    ]
		});
		jQuery('.testimonial-slider').slick({
			dots: false,
			speed: 800,
			infinite: true,
			slidesToShow: 3,
			slidesToScroll: 1,
			adaptiveHeight: true,
			autoplay: true,
			arrows: true,
			centerMode: true,
			centerPadding: '0',
			autoplaySpeed: 90000,
			responsive: [
				{ 
			      breakpoint: 992,
			      settings: {
			        slidesToShow: 2,
			        slidesToScroll: 1,
			      }
			    },
			    { 
			      breakpoint: 576,
			      settings: {
			      	arrows: false,
			      	dots: true,
			        slidesToShow: 1,
			        slidesToScroll: 1,
			      }
			    }
		    ]
		});
		jQuery('.project-slider').slick({
	      slidesToScroll: 1,
	      centerMode: true,
	      centerPadding: '24.5%',
	      autoplay: true,
	      arrows: false,
	      speed: 1000,
	      responsive: [
	        {
	          breakpoint: 1450,
	          settings: {
	            centerPadding: '13%'
	          }
	        },
	        {
	          breakpoint: 600,
	          settings: {
	            centerPadding: '19.20%'
	          }
	        },
	        {
	          breakpoint: 480,
	          settings: {
	            centerPadding: '0%'
	          }
	        }
	      ]
	    });
	    jQuery('.work-slider').slick({
	      slidesToScroll: 1,
	      centerMode: true,
	      centerPadding: '19.20%',
	      autoplay: true,
	      arrows: false,
	      speed: 1000,
	      responsive: [
	        {
	          breakpoint: 1450,
	          settings: {
	            centerPadding: '15%',
	          }
	        },
	            {
	          breakpoint: 1199,
	          settings: {
	            centerPadding: '20%',
	          }
	        },
	        {
	          breakpoint: 1024,
	          settings: {
	            centerPadding: '14.20%',
	          }
	        },
	        {
	          breakpoint: 768,
	          settings: {
	            centerPadding: '0%',
	          }
	        }
	      ]
	    });
	    jQuery('.partner-list').slick({
	      arrows: false,
	      dots: false,
	      speed: 1000,
	      slidesToShow: 5,
	      slidesToScroll: 1,
	      adaptiveHeight: true,
	      autoplay: true,
	      autoplaySpeed: 600,
	      responsive: [
	        {
	          breakpoint: 1024,
	          settings: {
	          slidesToShow: 3,
	          slidesToScroll: 1
	          }
	        },
	        {
	          breakpoint: 600,
	          settings: {
	         slidesToShow: 3,
	          slidesToScroll: 1
	          }
	        },
	        {
	          breakpoint: 480,
	          settings: {
	          slidesToShow: 2
	          }
	        }
	     ]
	    });
	    jQuery('.single-slider').slick({
	      arrows: false,
	      dots: false,
	      speed: 1000,
	      slidesToShow: 1,
	      slidesToScroll: 1,
	      adaptiveHeight: true,
	      autoplay: true,
	      arrows:true,
	      autoplaySpeed: 2000
	    });
	    jQuery('.testimonail-slider').slick({
	      dots: false,
	      speed: 1000,
	      slidesToShow: 1,
	      slidesToScroll: 1,
	      adaptiveHeight: true,
	      autoplay: true,
	      arrows: true,
	      fade: true,
	      autoplaySpeed: 4000,
	      responsive: [
	        {
	          breakpoint: 480,
	          settings: {
	          arrows: false,
	          dots: true
	          }
	        }
	     ]
	    });
	}


	initFancybox();
	// lightbox init
	function initFancybox() {
		jQuery('a.lightbox, [data-fancybox]').fancybox({
			parentEl: 'body',
			margin: [50, 0]
		});
	}


	initProgressBar();
	// Progress Bar init
	function initProgressBar() {
		if( jQuery(".progress-bar").length != '' ){
			var waypoint = new Waypoint({
				element: document.getElementById('progress-bar'),
				handler: function(direction) {
					console.log('Scrolled to startpoint!');
					jQuery('.progress-bar li').each(function() {
							var widthBar = jQuery(this).find('.over').attr('data-percent');
							jQuery(this).find('.over').animate({
								'width': widthBar
							});
					});
				},
				offset: '80%'
			});
		}
	}

	initStickyHeader();
	// sticky header init
	function initStickyHeader() {

		"use strict";

		var win = jQuery(window),
			stickyClass = 'sticky';

		jQuery('#header').each(function() {
			var header = jQuery(this);
			var headerOffset = header.offset().top || 0;
			var flag = true;


			jQuery(this).css('height' , jQuery(this).innerHeight());

			function scrollHandler() {
				if (win.scrollTop() > headerOffset) {
					if (flag){
						flag = false;
						header.addClass(stickyClass);
					}
				} else {
					if (!flag) {
						flag = true;
						header.removeClass(stickyClass);
					}
				}
			}

			scrollHandler();
			win.on('scroll resize orientationchange', scrollHandler);
		});
	}

	initCustomForms();
	// initialize custom form elements
	function initCustomForms() {
		jcf.replaceAll();
	}

	initTooltip();
	// hover tooltip init
	function initTooltip() {
		jQuery('a[title]').hoverTooltip({
			tooltipStructure: '<div class="hover-tooltip"><div class="tooltip-text"></div></div>'
		});
	}

	initOpenClose();
	// open-close init
	function initOpenClose() {
		jQuery('.open-close').openClose({
			activeClass: 'active',
			opener: '.opener',
			slider: '.slide',
			animSpeed: 400,
			effect: 'slide'
		});
	}
	

});

jQuery(window).on('load', function() {
	"use strict";

	//new WOW().init();
	
	initPreLoader()
	// PreLoader init
	function initPreLoader() {
	    "use strict";

	    jQuery('#loader').delay(1000).fadeOut();
	}

	initIsoTop();

	// IsoTop init
	function initIsoTop() {
		"use strict";

		var isotopeHolder = jQuery('.gallery-holder, .project-holder'),
			win = jQuery(window);
		jQuery('.filter-list a').on( "click", function(e){
			e.preventDefault();
			
			jQuery('.filter-list li').removeClass('active');
			jQuery(this).parent('li').addClass('active');
			var selector = jQuery(this).attr('data-filter');
			isotopeHolder.isotope({ filter: selector });
		});
		jQuery('.gallery-holder, .project-holder').isotope({
			itemSelector: '.gallary-img, .col, .project-block',
			transitionDuration: '0.6s',
			masonry: {
		    	columnWidth: '.gallary-img, .col, .project-block'
			}
		});
	}

});