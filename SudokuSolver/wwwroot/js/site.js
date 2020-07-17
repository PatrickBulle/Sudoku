$(document).ready(function () {
    $('td.valeurInit').attr('contenteditable', false).css('font-weight', 'bold');
    $('#sudoku').addClass('initialise');
    $('#init-sudoku').on('click', function () {
        var nbRows = $('#sudoku').data('number-rows');
        var nbColumns = $('#sudoku').data('number-columns');
        $('.valeurInit').removeClass('valeurInit');
        var tabCellules = [];
        for (var i = 0; i < nbRows; i++) {
            var tabRow = [];
            for (var j = 0; j < nbColumns; j++) {
                var value = $('.row-' + i + '.column-' + j).text().trim();
                var x = parseInt(value);
                if (isNaN(x)) {
                    $('.row-' + i + '.column-' + j).text('');
                    x = 0;
                } else {
                    $('.row-' + i + '.column-' + j).addClass('valeurInit');
                }
                tabRow.push(x);
            }
            tabCellules.push(tabRow);
        }
        $.ajax({
            type: "POST",
            url: "Home/Init",
            data: { value: tabCellules },
            success: function (response) {
                if (response == true) {
                    $('.valeurInit').attr('contenteditable', false).css('font-weight', 'bold');
                    $('#sudoku').addClass('initialise');
                } else {
                    alert('Erreur pendant l\'initialisation');
                }
            }
        });
        console.log(tabCellules);
    });
    $("#sudoku td").on('keypress', function (e) {
        if (isNaN(String.fromCharCode(e.which)) || $(this)[0].innerText !== "") {
            e.preventDefault()
        } else {
            if ($('#sudoku').hasClass('initialise')) {
                var txt = String.fromCharCode(e.which);
                var value = 0;
                if (txt !== "") {
                    value = parseInt(txt);
                }
                var posX = $(this).data('cell-row');
                var posY = $(this).data('cell-column');
                $.ajax({
                    type: "POST",
                    url: "Home/SetValeurCellule",
                    data: { posX: posX, posY: posY, value: value },
                    success: function (response) {
                        if (response == true) {
                        } else {
                            alert('Valeur impossible');
                            $(this).text('');
                        }
                    }
                });        
            }
        }
    });
    $('#resolve-sudoku').on('click', function () {
        $.ajax({
            type: "POST",
            url: "Home/Resoudre",
            success: function (data) {
                //var data = JSON.parse(response);
                for (var i = 0; i < data.length; i++) {
                    for (var j = 0; j < data[i].length; j++) {
                        if (!data[i][j].estValeurInitiale && data[i][j].estTrouve) {
                        //if (!$('.row-' + i + '.column-' + j).hasClass('valeurInit')) {
                            $('.row-' + i + '.column-' + j).text(data[i][j].valeur);
                            $('.row-' + i + '.column-' + j).addClass('valeurTrouvee');
                            $('.row-' + i + '.column-' + j).attr('contenteditable', false);
                            $('.row-' + i + '.column-' + j).css('font-weight', 'bold');
                        }
                    }
                }
            }
        });
    });
    $('#resolve-sudoku-par-etape').on('click', function () {
        $.ajax({
            type: "POST",
            url: "Home/ResoudreParEtape",
            success: function (data) {
                //var data = JSON.parse(response);
                for (var i = 0; i < data.length; i++) {
                    for (var j = 0; j < data[i].length; j++) {
                        if (!data[i][j].estValeurInitiale && data[i][j].estTrouve) {
                            //if (!$('.row-' + i + '.column-' + j).hasClass('valeurInit')) {
                            $('.row-' + i + '.column-' + j).text(data[i][j].valeur);
                            $('.row-' + i + '.column-' + j).addClass('valeurTrouvee');
                            $('.row-' + i + '.column-' + j).attr('contenteditable', false);
                            $('.row-' + i + '.column-' + j).css('font-weight', 'bold');
                        }
                    }
                }
            }
        });
    });  
    $('#vide-sudoku').on('click', function () {
        $.ajax({
            type: "POST",
            url: "Home/Vider",
            success: function (data) {
                $('#sudoku').removeClass('initialise');
                $('#sudoku td').text('').attr('contenteditable', true).css('font-weight', 'normal').removeClass('valeurInit').removeClass('valeurTrouvee');
            }
        });
    });
    $('#restaure-sudoku').on('click', function () {
        $.ajax({
            type: "POST",
            url: "Home/Restaurer",
            success: function (data) {
                $('#sudoku td.valeurTrouvee').text('').attr('contenteditable', true).css('font-weight', 'normal').removeClass('valeurTrouvee');
            }
        });
    });


    $.contextMenu({
        selector: '#sudoku td:not(.valeurInit, .valeurTrouvee)',
        callback: callbackContextMenu,
        items: {
            "resolve": {
                name: "Résoudre",
                icon: "edit",
                callback: callbackContextMenu
            }
        }
    });

});
function callbackContextMenu(key, options) {
    var cellule = $(this);
    var posX = cellule.data('cell-row');
    var posY = cellule.data('cell-column');
    $.ajax({
        type: "POST",
        url: "Home/ResoudreCellule",
        data: { posX: posX, posY: posY },
        success: function (data) {
            if (data != undefined) {
                if (data.valeur != 0) {
                    cellule.text(data.valeur).attr('contenteditable', false).css('font-weight', 'bold').addClass('valeurTrouvee');
                }
            } else {
                alert("On ne peut pas trouver cette cellule");
            }
        }
    });
}