window.onload = function resetRadioButton()
{
    document.getElementById('devCheck').checked = false;
    document.getElementById('buyerCheck').checked = false;
}

function devBuyerCheck()
{
    if (document.getElementById('devCheck').checked)
    {
        document.getElementById('ifDev').style.display = '';
        document.getElementById('ifBuyer').style.display = 'none';
    }
    else if (document.getElementById('buyerCheck').checked)
    {
        document.getElementById('ifBuyer').style.display = '';
        document.getElementById('ifDev').style.display = 'none';
    }
}