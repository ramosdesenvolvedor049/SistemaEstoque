function excluirProduto(id) {
    $.ajax({
        url: '/Estoque/excluir/' + id,
        type: 'POST',
        success: function (result) {
            if (result.success) {
                alert('Produto excluído com sucesso!');
                
            } else {
                alert('Erro ao excluir produto!');
            }
            location.reload(true);
        }
    });
}

$(document).ready(function () {
    $('#minhaTabela').DataTable();
});

$("#btnSalvar").click(function () {
    var txtNome = $("#txtNome").val();

    $.ajax({
        type: "POST",
        url: "/Estoque/Salvar",
        data: { txtNome, txtNome },
        success: function (response) {

            if (response.success) {
                alert("Produto salvo com sucesso!");
            } else {
                alert(response.message);
            }
            $("#txtNome").val('');
            location.reload(true);
        }
    });
});



