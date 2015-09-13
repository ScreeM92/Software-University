function numbersOnly(){
	var field = document.getElementById('numberField');
	var inputValue = field.value;
	if (isNaN(inputValue)) {
		var field = document.getElementById('numberField');
		field.style.backgroundColor = 'red';
		field.disabled = true;
		field.value = "";	
	}
setTimeout(function (){	field.style.backgroundColor = 'transparent';
		field.disabled = false; field.focus()}, 2000);
}