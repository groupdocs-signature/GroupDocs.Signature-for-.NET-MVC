/**
 * Basic Color Picker
 * Copyright (c) 2018 Alex Bobkov <lilalex85@gmail.com>
 * Licensed under MIT
 * @author Alexandr Bobkov
 * @version 0.2.0
 */

$(document).ready(function(){

	// Toggle color picker
	$('body').on('click', '.bcPicker-picker', function(){
		$.fn.bcPicker.toggleColorPalette($(this));
	});

	// Pick a color
	$('.bcPicker-palette').on('click', '.bcPicker-color', function(){
		$.fn.bcPicker.pickColor($(this));
	});
});



(function( $ ) {
	/**
	* Private variables
	**/
	var templates = {
		picker 	: $('<div class="bcPicker-picker"></div>'),
		palette : $('<div class="bcPicker-palette"></div>'),
		color 	: $('<div class="bcPicker-color"></div>')
	};

	/**
	* Color picker assembly
	**/
	$.fn.bcPicker = function (options) {

		return this.each(function () {
			var elem 			= $(this),
				colorSet		= $.extend({}, $.fn.bcPicker.defaults, options),
				defaultColor	= $.fn.bcPicker.toHex( (elem.val().length > 0) ? elem.val() : colorSet.defaultColor),
				picker 			= templates.picker.clone(),
				palette 		= templates.palette.clone(),
				color;

			// add position relative to root element
			elem.css('position', 'relative');

			// append picker
			elem.append(picker);
			picker.css('background-color', defaultColor);

			// append palette
			elem.append(palette);

			// assembly color palette
			$.each(colorSet.colors, function (i) {
        		color = templates.color.clone();
				color.css('background-color',  $.fn.bcPicker.toHex(colorSet.colors[i]));
				palette.append(color);
    		});

		});
	}

	/**
	* Color picker functions
	**/
	$.extend(true, $.fn.bcPicker, {

		/**
		* Toggle color palette
		**/
		toggleColorPalette : function(elem){
			elem.next().toggle('fast');
		},

		/**
		* Pick color action
		**/
		pickColor : function(elem){
			// get selected color
			var pickedColor = elem.css('background-color');
			// set picker with selected color
			elem.parent().parent().find('.bcPicker-picker').css('background-color', pickedColor);
			elem.parent().toggle('fast');
		},

		/**
		* Convert color to HEX value
		**/
		toHex : function(color) {
		    // check if color is standard hex value
		    if (color.match(/[0-9A-F]{6}|[0-9A-F]{3}$/i)) {
		        return (color.charAt(0) === "#") ? color : ("#" + color);
		    // check if color is RGB value -> convert to hex
		    } else if (color.match(/^rgb\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*\)$/)) {
		        var c = ([parseInt(RegExp.$1, 10), parseInt(RegExp.$2, 10), parseInt(RegExp.$3, 10)]),
		            pad = function (str) {
		                if (str.length < 2) {
		                    for (var i = 0, len = 2 - str.length; i < len; i++) {
		                        str = '0' + str;
		                    }
		                }
		                return str;
		            };
		        if (c.length === 3) {
		            var r = pad(c[0].toString(16)),
		                g = pad(c[1].toString(16)),
		                b = pad(c[2].toString(16));
		            return '#' + r + g + b;
		        }
		    // else do nothing
		    } else {
		        return false;
		    }
		}

	});

	/**
	* Default color values
	**/
	$.fn.bcPicker.defaults = {
        // default color
        defaultColor : "000000",

        // default color set
        colors : [
					'000000', '993300', '333300', '000080', '333399', '333333',
					'800000', 'FF6600', '808000', '008000', '008080', '0000FF',
					'666699', '808080', 'FF0000', 'FF9900', '99CC00', '339966',
					'33CCCC', '3366FF', '800080', '999999', 'FF00FF', 'FFCC00',
					'FFFF00', '00FF00', '00FFFF', '00CCFF', '993366', 'C0C0C0',
					'FF99CC', 'FFCC99', 'FFFF99', 'CCFFFF', '99CCFF', 'FFFFFF'
        ],

        // extend default set
        addColors : [],
    };

})(jQuery);
