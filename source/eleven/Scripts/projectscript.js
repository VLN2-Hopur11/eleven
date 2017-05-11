$("#editorform").submit(function () {
    $("#hidden_editor").val(editor.getSession().getValue());
});

var codeHub = $.connection.codeHub;
var silent = false;
codeHub.client.onChange = function (changeData){
    silent = true;
    console.log(changeData);
    editor.getSession().getDocument().applyDelta(changeData);
    silent = false;
};

$.connection.hub.start().done(function () {
    codeHub.server.joinDocument(documentID);
    editor.on("change", function (obj) {
        if(silent){
            return;
        }
        console.log(obj);
        codeHub.server.onChange(obj, documentID);
    });
});

$("#inviteuser").click(function () {
    $("#invitationform").toggleClass("hidden");
})

$("#newfile").click(function () {
    $("#newfileform").toggleClass("hidden");
})

$("#newfolder").click(function () {
    $("#newfolderform").toggleClass("hidden");
})

$("#findandreplace").click(function () {
    $("#replaceinputs").toggleClass("hidden");
})

$("#replacebutton").click(function () {
    var theFind = $('#find').val();
    var theReplace = $('#replace').val();
    editor.find(theFind);
    editor.replace(theReplace);
})

$("#replaceallbutton").click(function () {
    var editor = ace.edit("editor");
    var theFind = $('#find').val();
    var theReplace = $('#replace').val();
    editor.find(theFind);
    editor.replaceAll(theReplace);
})

$('#theme').change(function () {
    var editor = ace.edit("editor");
    if ($(this).val() === "one") {
        editor.setTheme("ace/theme/monokai");
    }
    if ($(this).val() === 'two') {
        editor.setTheme("ace/theme/chrome");
    }
    if ($(this).val() === 'three') {
        editor.setTheme("ace/theme/twilight");
    }
    if ($(this).val() === 'four') {
        editor.setTheme("ace/theme/chaos");
    }
    if ($(this).val() === 'five') {
        editor.setTheme("ace/theme/ambiance");
    }
});

$('#mode').change(function () {
    var editor = ace.edit("editor");
    if ($(this).val() === '1') {
        editor.getSession().setMode("ace/mode/javascript");
    }
    if ($(this).val() === '2') {
        editor.getSession().setMode("ace/mode/json");
    }
    if ($(this).val() === '3') {
        editor.getSession().setMode("ace/mode/xml");
    }
    if ($(this).val() === '4') {
        editor.getSession().setMode("ace/mode/php");
    }
    if ($(this).val() === '5') {
        editor.getSession().setMode("ace/mode/html");
    }
});

