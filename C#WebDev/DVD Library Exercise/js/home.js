$(document).ready(function () {
$('#dvd-button').on('click', function(){
	
	$.ajax({
		type: "GET",
		url: "http://api.openweathermap.org/data/2.5/weather?zip=" + $('').val() + ",us&appid=785c275a3e4953ca6548cae4f4f0ccd2",
		success: function (data){
		//var 
		}
	});
	
	
});
$('td').hover(
	function() {
		$(this).css('backgroundColor', 'WhiteSmoke');
	},
	function() {
		$(this).css('backgroundColor', '');
	S
	});
});
