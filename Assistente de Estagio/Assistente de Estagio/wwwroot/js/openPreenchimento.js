var open = false;
var userId = null;

/*
 * SimpleModal OSX Style Modal Dialog
 * http://simplemodal.com
 *
 * Copyright (c) 2013 Eric Martin - http://ericmmartin.com
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 */

function Download(idDocumento) { //padrão   Download(idDocumento,idUsuario) 
    if (userId !== null) {
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: serviceURL,
            data: {
                userId: userId,
                idDocumento: idDocumento
            },
            success: function () {

            }
        });
    } else {
       // document.getElementById("interface-preenchimento-popup").style.display = "initial";
        document.getElementById("modal-backdrop").style.display = "initial";
        open = true;
    }
}
var modal = document.getElementById('modal-backdrop');
window.onclick = function (event) {
    if (open === true) {
        if (event.target === modal) {
            modal.style.display = "none";
            open = false;
        }
        
    }
}