/**
 * groupdocs.signature Plugin
 * Copyright (c) 2018 Aspose Pty Ltd
 * Licensed under MIT.
 * @author Aspose Pty Ltd
 * @version 1.0.0
 */

(function( $ ) {

	/**
	* Create private variables.
	**/
	var paramValues = {	
		text : 'gd-qr-text',
		borderColor : 'gd-qr-border-color',
		borderStyle : 'gd-qr-border-style',
		borderWidth : 'gd-qr-border-width'
	}

	$.fn.opticalCodeGenerator = function() {
        if ($("#gd-qr-container").length == 0) {
            $(this).append($.fn.opticalCodeGenerator.baseHtml());
			var propertiesContainer = "";
			if(/Mobi/.test(navigator.userAgent)) {
				propertiesContainer = $.fn.opticalCodeGenerator.propertiesHtmlMobile();
			} else {
				propertiesContainer = $.fn.opticalCodeGenerator.propertiesHtml();
			}
            $("#gd-qr-params-header").append(propertiesContainer);
            $('#' + paramValues.borderColor).bcPicker();
        }
	}

	$.extend(true, $.fn.opticalCodeGenerator, {

        getProperties : function(){
				var text = $(this).find('#' + paramValues.text).val();
				var borderColor = $('#' + paramValues.borderColor).children().css('background-color');
            	var borderStyle = parseInt($(this).find('#' + paramValues.borderStyle).val());
				var borderWidth = $(this).find('#' + paramValues.borderWidth).val();
				var properties = {text: text, borderColor: borderColor, borderStyle: borderStyle, borderWidth: borderWidth};
				return properties;
		},

		baseHtml : function(){
			var html = '<div id="gd-qr-container">' +
				'<div id="gd-qr-params-container">' +
					'<div id="gd-qr-params-header">' +
						// QR-Code properties will be here
					'</div>' +
				'</div>' +
				'<div id="gd-qr-preview-container"></div>' +
			'</div>';
			return html;
		},

		propertiesHtml : function(){
			var html = '<div class="gd-qr-params" id="gd-qr-params">'+
							'<h3>Signature Properties</h3>' +
							'<table id="gd-qr-text-table">'+								
								'<tbody>'+
									'<tr>'+
										'<td><div class="gd-optical-label">text</div><input type="text" id="' + paramValues.text + '" class="gd-qr-property" value="this is my text "/></td>'+
										'<td><div class="gd-optical-label gd-optical-color">border color</div><div class="gd-qr-color-picker gd-qr-property" id="' + paramValues.borderColor + '"></div></td>'+
										'<td>'+
											'<div class="gd-optical-label">border style</div>'+
											'<div class="gd-border-style-wrapper">'+
												'<select class="gd-border-style-select gd-qr-property" id="' + paramValues.borderStyle + '">'+
													'<option value="0">Dash</option>'+
													'<option value="1">DashDot</option>'+
													'<option value="2">DashDotDot</option>'+
                									'<option value="3">DashLongDash</option>'+
													'<option value="4">DashLongDashDot</option>'+
													'<option value="5">RoundDot</option>'+
													'<option value="6">Solid</option>'+
													'<option value="7">SquareDot</option>'+
												'</select>'+
											'</div>'+
										'</td>'+
										'<td><div class="gd-optical-label">Border width</div><input type="number" class="gd-qr-property" id="' + paramValues.borderWidth + '" value="0"/></td>'+
									'</tr>'+
								'</tbody>'+
							'</table>'+							
						'</div>';
			return html;
		},
		
		propertiesHtmlMobile : function(){
			var html = '<div class="gd-qr-params" id="gd-qr-params">'+
							'<h3>Signature Properties</h3>' +
							'<table id="gd-qr-text-table">'+								
								'<tbody>'+
									'<tr>'+
										'<td><div class="gd-optical-label">text</div><input type="text" id="' + paramValues.text + '" class="gd-qr-property" value="this is my text "/></td>'+
									'</tr>'+
								'</tbody>'+
							'</table>'+	
							'<table id="gd-qr-border-table">'+								
								'<tbody>'+
									'<tr>'+
										'<td><div class="gd-optical-label gd-optical-color">border color</div><div class="gd-qr-color-picker gd-qr-property" id="' + paramValues.borderColor + '"></div></td>'+
										'<td>'+
											'<div class="gd-optical-label">border style</div>'+
											'<div class="gd-border-style-wrapper gd-optical-border-style-wrapper">'+
												'<select class="gd-border-style-select gd-qr-property" id="' + paramValues.borderStyle + '">'+
													'<option value="0">Dash</option>'+
													'<option value="1">DashDot</option>'+
													'<option value="2">DashDotDot</option>'+
                									'<option value="3">DashLongDash</option>'+
													'<option value="4">DashLongDashDot</option>'+
													'<option value="5">RoundDot</option>'+
													'<option value="6">Solid</option>'+
													'<option value="7">SquareDot</option>'+
												'</select>'+
											'</div>'+
										'</td>'+
										'<td><div class="gd-optical-label">Border width</div><input type="number" class="gd-qr-property" id="' + paramValues.borderWidth + '" value="0"/></td>'+
									'</tr>'+
								'</tbody>'+
							'</table>'+							
						'</div>';
			return html;
		}
	});

})(jQuery);