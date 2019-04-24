var FormDropzone = function () {
    return {
        //main function to initiate the module
        init: function () {

            Dropzone.options.myDropzone = {
                init: function () {
                    this.on("addedfile", function (file) {
                        // Create the remove button
                        var removeButton = Dropzone.createElement("<button class='btn btn-sm btn-block'>Remove file</button>");

                        // Capture the Dropzone instance as closure.
                        var _this = this;

                        // Listen to the click event
                        removeButton.addEventListener("click", function (e) {
                            // Make sure the button click doesn't submit the form:
                            e.preventDefault();
                            e.stopPropagation();

                            // Remove the file preview.
                            _this.removeFile(file);
                            // If you want to the delete the file on the server as well,
                            // you can do the AJAX request here.

                            var formData = new FormData();
                            //var file = document.getElementById(id).files[0];
                            
                            if (file.status == "success") {

                                formData.append("file", file);

                                //call controller for delete data by hamka
                                $.ajax({
                                    type: "POST",
                                    url: location.origin + '/DataFile/DeleteDataFile/',
                                    contentType: false,
                                    processData: false,
                                    data: formData
                                });
                            }
                        });

                        // Add the button to the file preview element.
                        file.previewElement.appendChild(removeButton);

                        //remove no image
                        var noimage = document.getElementById("no-image");
                        if (noimage != null) {
                            $("#no-image").hide();
                            noimage.hidden = true;
                        }
                        
                    });
                }
            }
        }
    };
}();