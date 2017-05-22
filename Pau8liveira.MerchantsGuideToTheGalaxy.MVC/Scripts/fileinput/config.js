var urlPost = $("#urlPost").val();
var maxFileSize = 1000;

$(document).ready(function () {
            
    $('#kv-explorer').fileinput({
        'uploadUrl': urlPost,
        maxFileSize: maxFileSize,
        previewFileType: 'text',
        allowedFileExtensions: ['txt', 'text'],
        uploadAsync: false,
        elErrorContainer: '#errorBlock'
    })
    .on('filebatchuploadsuccess', function (event, data) {
        var response = data.response;

        if (response.ExceptionMessage.length > 0) {
            var message = "<ul>";
            $.each(response.ExceptionMessage, function (key, obj) {
                message += "<li>" + obj.Message + "</li>";
            });
            message += "</ul>"
            $("#errorCustomBlock").html(message);
            $('#errorCustomBlock').fadeIn('slow');
        }
        else
        {
            var lines = "";
            $.each(response.Results, function (key, obj) {
                lines += "<tr>"; 
                lines += "    <th scope='row'>" + obj.Text + "</th>"; 
                lines += "    <td>" + obj.Translation + "</td>";
                lines += "</tr>";
            });
            $("#tbodyResults").html(lines);
            $('#tableResults').fadeIn('slow');
        }
    });
 
});