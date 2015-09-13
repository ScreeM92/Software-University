/*
	Author: Salimur Mamum Rahman
	Notes: Thank much SoftUni for teach me quality code!
*/

// Change later to a more concrete selector
var selector = document.body;

// Trigger file selection window
$(selector).on('click', '#upload-file-button', function() {
	$('#picture').click();
});

// Reads the selected file and returns the data as a base64 encoded string
$(selector).on('change', '#picture', function() {
	var file = this.files[0],
		reader;

    console.log(file);

    if(!file.type.match(/image\/.*/)){
        Noty.error("Invalid file format.");
    } else if(file.size > 131072) {
        Noty.error("File size limit exceeded.");
    } else {
        reader = new FileReader();
        reader.onload = function() {
            $('.picture-name').text(file.name);
            $('.picture-preview').attr('src', reader.result);
            $('#picture').attr('data-picture-data', reader.result);
        };
        reader.readAsDataURL(file);
    }
});