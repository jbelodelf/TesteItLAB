var idTipoProduto = "";
Produto = {
    Listar: function () {
        var url = "/Produto/ListarProdutos";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , cache: false
        }).done(function (data) {
            $("#dvListarProdutos").html(data);
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },
    
    Salvar: function () {
        var isValido = true;

        if ($("#Nome").val() == "") {
            isValido = false;
        }
        else if ($("#Tipo").val() == "") {
            isValido = false;
        }
        else if ($("#DataFabricacao").val() == "") {
            isValido = false;
        }
        else if ($("#Valor").val() == "" || $("#Valor").val() == 0) {
            isValido = false;
        }
        else if ($("input[name='rdDisponivel']:checked").val() == "" || $("input[name='rdDisponivel']:checked").val() == undefined) {
            isValido = false;
        }

        if (!isValido) {
            $("#mensagemModal").text("*Favor preencher os campos obrigatórios!!!").show();
            window.setTimeout(function () {
                $("#mensagemModal").text("").hide();
            }, 6000);
            return;
        }
        bootbox.confirm({
            message: 'Deseja realmente salvar este produto?',
            buttons: {
                confirm: {
                    label: 'Sim',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Não',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (!result) {
                    controle = true;
                    return;
                }
                var url = "/Produto/Salvar";

                produto = {
                    ID: $("#IdProduto").val(),
                    NOME: $("#Nome").val(),
                    IDTIPO: $("#Tipo").val(),
                    DTFABRICACAO: $("#DataFabricacao").val(),
                    VALOR: $("#Valor").val().replace("R$", "").trim(),
                    DATACADASTRO: $("#DATACADASTRO").val(),
                    DISPONIVEL: $("input[name='rdDisponivel']:checked").val() == "1" ? true : false,
                    NORTE: $("input[name='cbNorte']:checked").val() == "S" ? $("input[name='cbNorte']:checked").val() : "",
                    SUL: $("input[name='cbSul']:checked").val() == "S" ? $("input[name='cbSul']:checked").val() : "",
                    LESTE: $("input[name='cbLeste']:checked").val() == "S" ? $("input[name='cbLeste']:checked").val() : "",
                    OESTE: $("input[name='cbOeste']:checked").val() == "S" ? $("input[name='cbOeste']:checked").val() : ""
                };

                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "POST"
                    , async: false
                    , data: { produto: produto }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno) {
                        $("#mensagemModal").text(data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemModal").text("").hide();
                            $("#ModalCadastrarProduto").modal('hide');
                            Produto.Listar();
                        }, 3000);
                    }
                    else {
                        $("#mensagemModal").text('Erro:' + data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemModal").text("").hide();
                            $("#ModalCadastrarProduto").modal('hide');
                            Produto.Listar();
                        }, 3000);
                        return;
                    }
                }).fail(function (jqXHR, exception) {
                    TratamentoDeErro(jqXHR, exception);
                });
            }
        });
    },

    Editar: function (idProduto) {
        var url = "/Produto/EditarProduto";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { id: idProduto }
            , cache: false
        }).done(function (data) {
            if (data.produto != null) {
                idTipoProduto = data.produto.idtipo;
                var valor = parseFloat(data.produto.valor).toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

                $("#IdProduto").val(data.produto.id);
                $("#Nome").val(data.produto.nome);
                $('#Tipo option[value="' + data.produto.idtipo + '"]').attr({ selected: "selected" });
                $("#DataFabricacao").val(ConvertToData(data.produto.dtfabricacao));
                $("#Valor").val(valor);
                $("#DATACADASTRO").val(ConvertDateTime(data.produto.datacadastro));
                if (data.produto.disponivel)
                    $("input[type=radio][value='1']").prop("checked", true);
                else
                    $("input[type=radio][value='0']").prop("checked", true);
                if (data.produto.norte == "S")
                    $("input[name='cbNorte']").prop('checked', true);
                if (data.produto.sul == "S")
                    $("input[name='cbSul']").prop('checked', true);
                if (data.produto.leste == "S")
                    $("input[name='cbLeste']").prop('checked', true);
                if (data.produto.oeste == "S")
                    $("input[name='cbOeste']").prop('checked', true);

                $("#ModalCadastrarProduto").modal('show');
            }
            else {
                return;
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },
    
    Delete: function (idProduto) {
        bootbox.confirm({
            message: 'Deseja realmente deletar este produto?',
            buttons: {
                confirm: {
                    label: 'Sim',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Não',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (!result) {
                    controle = true;
                    return;
                }
                var url = "/Produto/DeletarProduto";
                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "GET"
                    , async: false
                    , data: { Id: idProduto }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno) {
                        $("#mensagemPagina").text(data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemPagina").text("").hide();
                            Produto.Listar();
                        }, 3000);
                    }
                    else {
                        $("#mensagemPagina").text('Erro: ' + data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemPagina").text("").hide();
                            Produto.Listar();
                        }, 3000);
                        return;
                    }
                }).fail(function (jqXHR, exception) {
                    TratamentoDeErro(jqXHR, exception);
                });
            }
        });
    },

    ChecarDuplicidade: function () {
        var nome = $("#Nome").val();
        if (nome == "") {
            return;
        }

        var url = "/Produto/ChecarDuplicidade";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { Nome: nome }
            , cache: false
        }).done(function (data) {
            if (data.retorno) {
                $("#mensagemModal").text(data.mensagem).show();
                window.setTimeout(function () {
                    $("#mensagemModal").text("").hide();
                    $("#Nome").focus();
                }, 3000);
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    }
}

$(document).ready(function () {
    $('#Valor').mask("#.##0,00", { reverse: true });

    var url = window.location.pathname;
    if ((url == "/") || (url == "/Produto") || (url == "/Produto/Index") || (url == "/Produto/")) {
        Produto.Listar();
    }

    $("#btnSalvarProduto").on("click", function () {
        Produto.Salvar();
    });

    $('#btNovo').on("click", function () {
        $("#IdProduto").val("0");
        $("#Nome").val("");
        $('#Tipo option[value="' + idTipoProduto + '"]').removeAttr("selected");
        $("#DataFabricacao").val("");
        $("#Valor").val("");
        $("input[type=radio][value='1']").prop("checked", true);
        $("input[name='cbNorte']").prop('checked', false);
        $("input[name='cbSul']").prop('checked', false);
        $("input[name='cbLeste']").prop('checked', false);
        $("input[name='cbOeste']").prop('checked', false);
       
        $("#ModalCadastrarProduto").modal('show');
    });

    $('#btnFecharProduto').on("click", function () {
        $("#IdProduto").val("0");
        $("#Nome").val("");
        $('#Tipo option[value="' + idTipoProduto + '"]').removeAttr("selected");
        $("#DataFabricacao").val("");
        $("#Valor").val("");
        $("input[type=radio][value='1']").prop("checked", true);
        $("input[name='cbNorte']").prop('checked', false);
        $("input[name='cbSul']").prop('checked', false);
        $("input[name='cbLeste']").prop('checked', false);
        $("input[name='cbOeste']").prop('checked', false);

        $("#ModalCadastrarProduto").modal('hide');
    });

    $("#Nome").on("blur", function () {
        Produto.ChecarDuplicidade();
    });

});

function ConvertDateTime(date) {
    if (date == null)
        return "";

    var d = new Date(date);
    var dia = d.getDate().toString();
    var mes = (d.getMonth() + 1);
    var ano = d.getFullYear();
    var sdia = "";
    var smes = "";

    if (dia.toString().length == 1) {
        sdia = "0" + dia.toString();
    } else {
        sdia = dia.toString();
    }

    if (mes.toString().length == 1) {
        smes = "0" + mes.toString();
    } else {
        smes = mes.toString();
    }

    var dataConv = new Date(ano.toString(), smes - 1, sdia);
    var ano = dataConv.getFullYear();
    var mes = dataConv.getMonth().toString().length == 1 ? '0' + (dataConv.getMonth() + 1).toString() : (dataConv.getMonth() + 1);
    var dia = dataConv.getDate().toString().length == 1 ? '0' + dataConv.getDate().toString() : dataConv.getDate();
    var dateTimeFinal = ano + '-' + mes + '-' + dia + ' ' + ConvertToTime(date)

    return dateTimeFinal;
}

function ConvertToTime(date) {
    if (date == null)
        return "";
    var d = new Date(date);
    var hora = d.getHours();
    var minuto = d.getMinutes();
    var segundo = d.getSeconds() == 0 ? 1 : d.getSeconds();
    var sminuto = "";
    var ssegundo = "";

    if (hora.toString().length == 1) {
        shora = "0" + hora.toString();
    } else {
        shora = hora.toString();
    }

    if (minuto.toString().length == 1) {
        sminuto = "0" + minuto.toString();
    } else {
        sminuto = minuto.toString();
    }

    if (segundo.toString().length == 1) {
        ssegundo = "0" + segundo.toString();
    } else {
        ssegundo = segundo.toString();
    }

    var horaFinal = shora + ':' + sminuto + ':' + ssegundo;

    return horaFinal;
}

function ConvertToData(date) {
    if (date == null)
        return "";

    var d = new Date(date);
    var dia = d.getDate().toString();
    var mes = (d.getMonth() + 1);
    var ano = d.getFullYear();
    var sdia = "";
    var smes = "";

    if (dia.toString().length == 1) {
        sdia = "0" + dia.toString();
    } else {
        sdia = dia.toString();
    }

    if (mes.toString().length == 1) {
        smes = "0" + mes.toString();
    } else {
        smes = mes.toString();
    }

    var dataConv = new Date(ano.toString(), smes - 1, sdia);
    var ano = dataConv.getFullYear();
    var mes = dataConv.getMonth().toString().length == 1 ? '0' + (dataConv.getMonth() + 1).toString() : (dataConv.getMonth() + 1);
    var dia = dataConv.getDate().toString().length == 1 ? '0' + dataConv.getDate().toString() : dataConv.getDate();
    var dataFinal = ano + '-' + mes + '-' + dia

    return dataFinal;
}