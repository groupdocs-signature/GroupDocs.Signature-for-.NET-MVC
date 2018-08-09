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
		text : 'gd-text-text',
		borderColor : 'gd-text-border-color',
		borderStyle : 'gd-text-border-style',
		borderWidth : 'gd-text-border-width',
        backgroundColor : 'gd-text-background',
		fontColor : 'gd-text-font-color',
		bold : 'gd-text-bold',
		italic : 'gd-text-italic',
        underline : 'gd-text-underline',
		font : 'gd-text-font',
		fontSize : 'gd-text-font-size',
        width : 200,
        height : 50
	}

	var properties = {};
	
	$.fn.textGenerator = function() {
        if ($("#gd-text-container").length == 0) {
            $(this).append($.fn.textGenerator.baseHtml());
			var propertiesContainer = "";
			if(/Mobi/.test(navigator.userAgent)) {
				propertiesContainer = $.fn.textGenerator.propertiesHtmlMobile();
			} else {
				propertiesContainer = $.fn.textGenerator.propertiesHtml();
			}
            $("#gd-text-params-header").append(propertiesContainer);
            $('#' + paramValues.borderColor).bcPicker();
            $('#' + paramValues.backgroundColor).bcPicker();
            $('#' + paramValues.fontColor).bcPicker();
        }
	}

	$.extend(true, $.fn.textGenerator, {

        getProperties : function(){
				var text = $(this).find('#' + paramValues.text).val();
				var borderColor = $('#' + paramValues.borderColor).children().css('background-color');
            	var borderStyle = parseInt($(this).find('#' + paramValues.borderStyle).val());
				var borderWidth = parseInt($(this).find('#' + paramValues.borderWidth).val());
				var backgroundColor = $('#' + paramValues.backgroundColor).children().css('background-color');
				var fontColor = $('#' + paramValues.fontColor).children().css('background-color');
            	var bold = $(this).find('#' + paramValues.bold).is(':checked') ? true : false;
            	var italic = $(this).find('#' + paramValues.italic).is(':checked') ? true : false;
            	var underline = $(this).find('#' + paramValues.underline).is(':checked') ? true : false;
            	var font = $(this).find('#' + paramValues.font).val();
           		var fontSize = parseInt($(this).find('#' + paramValues.fontSize).val());
				properties = {
					text: text,
					borderColor: borderColor,
					borderStyle: borderStyle,
					borderWidth: borderWidth,
                    backgroundColor: backgroundColor,
                    fontColor: fontColor,
					bold: bold,
					italic: italic,
					underline: underline,
					font: font,
					fontSize: fontSize,
                    width: paramValues.width,
                    height: paramValues.height
				};
				return properties;
		},

		draw : function(properties){
			$("#gd-text-preview-container").html('');
			$("#gd-text-preview-container").html(properties.text);
			$("#gd-text-preview-container").css("border-color", properties.borderColor);
			$("#gd-text-preview-container").css("border-style", properties.borderStyle);
			$("#gd-text-preview-container").css("border-width", properties.borderWidth + "px");
			$("#gd-text-preview-container").css("border-style", $('#gd-text-border-style option:selected').text());
			$("#gd-text-preview-container").css("background-color", properties.backgroundColor);
			$("#gd-text-preview-container").css("color", properties.fontColor);		
			if($("#gd-text-bold").parent().find("input").prop("checked")) {			
				$("#gd-text-preview-container").css("font-weight", "bold");
			} else {
				$("#gd-text-preview-container").css("font-weight", "unset");
			}
			if($("#gd-text-italic").parent().find("input").prop("checked")){
				$("#gd-text-preview-container").css("font-style", "italic");
			} else {
				$("#gd-text-preview-container").css("font-style", "unset");
			}
			if($("#gd-text-underline").parent().find("input").prop("checked")){
				$("#gd-text-preview-container").css("text-decoration", "underline");
			} else {
				$("#gd-text-preview-container").css("text-decoration", "unset");
			}
			$("#gd-text-preview-container").css("font-family", properties.font);
			$("#gd-text-preview-container").css("font-size", properties.fontSize);
		},
		
		baseHtml : function(){
			var html = '<div id="gd-text-container">' +
				'<div id="gd-text-params-container">' +
					'<div id="gd-text-params-header">' +
						// Text properties will be here
					'</div>' +
				'</div>' +
				'<div id="gd-text-preview-container" style="width: ' + paramValues.width + 'px; height: ' + paramValues.height + 'px;"></div>' +
			'</div>';
			return html;
		},

		propertiesHtml : function(){
			var html = '<div class="gd-text-params" id="gd-text-params">'+
							'<h3>Signature Properties</h3>' +
							'<table id="gd-text-table">'+
								'<tbody>'+
									'<tr>'+
										'<td>'+
                                            '<div class="gd-text-label">text</div>'+
                                            '<input type="text" id="' + paramValues.text + '" class="gd-text-property" value="this is my text "/>'+
                                        '</td>'+
										'<td>'+
                                            '<div class="gd-text-label">font color</div>' +
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.fontColor + '"></div>'+
                                        '</td>'+
                                        '<td>' +
                                            '<div class="gd-text-label">size</div>' +
                                            '<input type="number" class="gd-text-property" id="' + paramValues.fontSize + '" value="10"/>' +
                                        '</td>'+
										 '<td>'+
											'<div class="gd-text-checkboxes">'+
												'<div class="gd-text-checkbox gd-text-label">'+   
													'<label>'+
														'<input type="checkbox" id="' + paramValues.bold + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper "></i>bold'+
													'</label>'+
												'</div>'+
												'<div class="gd-text-checkbox gd-text-label">'+
													'<label class="gd-text-italic">'+
														'<input type="checkbox" id="' + paramValues.italic + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper "></i>italic'+
													'</label>'+
												'</div>'+
												'<div class="gd-text-checkbox gd-text-label">'+
													'<label class="gd-text-underline">'+
														'<input type="checkbox" id="' + paramValues.underline + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper gd-text-underline"></i>underline'+
													'</label>'+
												'</div>'+
											'</div>'+
                                        '</td>'+                						
									'</tr>'+									
                                '</tbody>'+
                            '</table>'+
							'<table id="gd-text-border-table">'+
								'<tbody>'+
									'<tr>'+
										'<td>'+
											'<div class="gd-text-label">font</div>'+
											'<input type="text" id="' + paramValues.font + '" class="gd-text-property" value="Arial"/>'+
										'</td>'+
										'<td>'+
                                            '<div class="gd-text-color gd-text-label">border color</div>'+
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.borderColor + '"></div>'+
                                        '</td>'+
                						'<td>'+
                                            '<div class="gd-text-color gd-text-label gd-text-background-color">background color</div>'+
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.backgroundColor + '"></div>'+
                                        '</td>'+
										'<td>'+
                                            '<div class="gd-text-label" id="gd-text-border-width-div">border width</div>'+
                                            '<input type="number" class="gd-text-property" id="' + paramValues.borderWidth + '" value="0"/>'+
                                        '</td>'+
                                        '<td id="gd-text-border-style-line">'+
                                            '<div class="gd-text-label">border style'+
												'<div class="gd-border-style-wrapper">'+
													'<select class="gd-border-style-select gd-text-property" id="' + paramValues.borderStyle + '">'+
														'<option value="0">solid</option>'+														
														'<option value="5">dotted</option>'+														
														'<option value="6">dashed</option>'+
													'</select>'+
												'</div>'+
                                            '</div>'+
                                        '</td>'+
									'</tr>'+
								'</tbody>'+
							'</table>'+
						'</div>';
			return html;
		},
		
		propertiesHtmlMobile : function(){
			var html = '<div class="gd-text-params" id="gd-text-params">'+
							'<h3>Signature Properties</h3>' +
							'<table id="gd-text-table">'+
								'<tbody>'+
									'<tr>'+
										'<td>'+
                                            '<div class="gd-text-label">text</div>'+
                                            '<input type="text" id="' + paramValues.text + '" class="gd-text-property" value="this is my text "/>'+
                                        '</td>'+
									'</tr>'+
								 '</tbody>'+
                            '</table>'+
							'<table id="gd-text-border-table">'+
								'<tbody>'+
									'<tr>'+
										'<td>'+
                                            '<div class="gd-text-label">font color</div>' +
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.fontColor + '"></div>'+
                                        '</td>'+
                                        '<td>' +
                                            '<div class="gd-text-label" id="gd-text-size-label">size</div>' +
                                            '<input type="number" class="gd-text-property" id="' + paramValues.fontSize + '" value="10"/>' +
                                        '</td>'+
										 '<td>'+
											'<div class="gd-text-checkboxes">'+
												'<div class="gd-text-checkbox gd-text-label">'+   
													'<label>'+
														'<input type="checkbox" id="' + paramValues.bold + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper "></i>bold'+
													'</label>'+
												'</div>'+
												'<div class="gd-text-checkbox gd-text-label">'+
													'<label class="gd-text-italic">'+
														'<input type="checkbox" id="' + paramValues.italic + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper "></i>italic'+
													'</label>'+
												'</div>'+
												'<div class="gd-text-checkbox gd-text-label">'+
													'<label class="gd-text-underline">'+
														'<input type="checkbox" id="' + paramValues.underline + '" class="gd-text-property" value="1"/>'+
														'<i class="gd-text-helper gd-text-underline"></i>underline'+
													'</label>'+
												'</div>'+
											'</div>'+
                                        '</td>'+
									'</tr>'+									
                                '</tbody>'+
                            '</table>'+
							'<table id="gd-text-border-table">'+
								'<tbody>'+
									'<tr>'+
										'<td>'+
											'<div class="gd-text-label">font</div>'+
											'<input type="text" id="' + paramValues.font + '" class="gd-text-property" value="Arial"/>'+
										'</td>'+
									   '<td>'+
                                            '<div class="gd-text-label" id="gd-text-border-width-div">border width</div>'+
                                            '<input type="number" class="gd-text-property" id="' + paramValues.borderWidth + '" value="0"/>'+
                                        '</td>'+
                                        '<td id="gd-text-border-style-line">'+
                                            '<div class="gd-text-label">border style'+
												'<div class="gd-border-style-wrapper">'+
													'<select class="gd-border-style-select gd-text-property" id="' + paramValues.borderStyle + '">'+
														'<option value="0">solid</option>'+														
														'<option value="5">dotted</option>'+														
														'<option value="6">dashed</option>'+
													'</select>'+
												'</div>'+
                                            '</div>'+
                                        '</td>'+ 						
									'</tr>'+
									'<tr>'+
										'<td>'+
                                            '<div class="gd-text-color gd-text-label gd-text-background-color">background color</div>'+
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.backgroundColor + '"></div>'+
                                        '</td>'+
										'<td>'+
                                            '<div class="gd-text-color gd-text-label">border color</div>'+
                                            '<div class="gd-text-color-picker gd-text-property" id="' + paramValues.borderColor + '"></div>'+
                                        '</td>'+ 
									'</tr>'+
								'</tbody>'+
							'</table>'+
						'</div>';
			return html;
		}
	});

})(jQuery);