window.onload = function IsCurrentDevInvolvedCheck() {
    if (CurrentDevIsInvolved == 'True') {
        document.getElementById('involved1').style.display = 'block';
        document.getElementById('involved2').style.display = 'block';
        document.getElementById('notInvolved1').style.display = 'none';
        document.getElementById('notInvolved2').style.display = 'none';
    }
    else {
        document.getElementById('notInvolved1').style.display = 'block';
        document.getElementById('notInvolved2').style.display = 'block';
        document.getElementById('involved1').style.display = 'none';
        document.getElementById('involved2').style.display = 'none';
    }
}