$(document).ready(function(){
    
    loadTheItems();

    itemTotals();
    var total = $('#')

$('#addDollarButton').click(function(){
        addDollar();
    });
    //adding dollar button
$('#addQuarterButton').click(function(){
        addQuarter();
    });
    //adding Quarter button
$('#addDimeButton').click(function(){
        addDime();
    });
    //adding Dime Button
$('#addNickelButton').click(function(){
        addNickel();
    });
    //adding Nickel Button
    makePurchase();
    makeChange();
    makePurchaseMessage();


    
});

function loadTheItems(){
    
    
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function(itemArray){
            $.each(itemArray, function(index, item){
                
                var id = item.id;
                
                var populate = $('#item' + id);

                  var  innerText = '<h4 id="name' + id + '">'+item.name +'</h4>';
                    innerText += '<p id="price' + id + '">' + '$'+ item.price +'</p>';
                    innerText += '<p id="quantity' + id + '">'+ 'Quantity: '+ item.quantity +'</p>';
                populate.html(innerText);

            });
        },
        error: function (){
            $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later'));
        }
    });
}


function addDollar(){
    var lastAmount = $("#totalForItem").val();
    var newAmount = Number(lastAmount) + 1.00;
    $("#totalForItem").val(newAmount.toFixed(2));
};
function addQuarter(){
    var lastAmount = $('#totalForItem').val();
    var newAmount = Number(lastAmount) + 0.25;
    $('#totalForItem').val(newAmount.toFixed(2));
};
function addDime(){
    var lastAmount = $('#totalForItem').val();
    var newAmount = Number(lastAmount) + 0.1;
    $('#totalForItem').val(newAmount.toFixed(2));
};
function addNickel(){
    var lastAmount = $('#totalForItem').val();
    var newAmount = Number(lastAmount) + 0.05;
    $('#totalForItem').val(newAmount.toFixed(2));
};

function itemTotals(){
$('#item1').on('click', function(){
     var price = $(this).find('#price1').text();
     $('#itemsCost').val(price);
   }),
$('#item2').on('click', function(){
     var price = $(this).find('#price2').text();
     $('#itemsCost').val(price);
   }),
$('#item3').on('click', function(){
     var price = $(this).find('#price3').text();
     $('#itemsCost').val(price);
   }),
$('#item4').on('click', function(){
     var price = $(this).find('#price4').text();
     $('#itemsCost').val(price);
   }),
$('#item5').on('click', function(){
     var price = $(this).find('#price5').text();
     $('#itemsCost').val(price);
   }),
$('#item6').on('click', function(){
     var price = $(this).find('#price6').text();
     $('#itemsCost').val(price);
   }),
$('#item7').on('click', function(){
     var price = $(this).find('#price7').text();
     $('#itemsCost').val(price);
   }),
$('#item8').on('click', function(){
     var price = $(this).find('#price8').text();
     $('#itemsCost').val(price);
   }),
$('#item9').on('click', function(){
     var price = $(this).find('#price9').text();
     $('#itemsCost').val(price);
   });
};

function makePurchase(item){
    $('#purchaseButton').click(function () {
       
        var id = item.id;
        var itemsPrice = $('.priceClass');
        var moneyDeposited = $('#totalForItem').val();

        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/money/'+  moneyDeposited + '/item/' +itemsId,
            success: function(status, item){
                $('#purchaseMessage').text("Thank You!");
                var quarters = (item.quarters)* .25;
                var dimes = (item.dimes)* .10;
                var nickels = (item.nickels)* .05;
                var pennies = (item.pennies)* .01;
                $('#itemBox').val((quarters+dimes+nickels+pennies).toFixed(2));

                $('#totalForItem').val(parseFloat(moneyDeposited - itemsPrice).toFixed(2));

            },

        error: function(response){
            $('#purchaseMessage').empty();
            $('#purchaseMessage').alert("an error has occured")
            console.log("error", response);
        }
        })
    });
};

function makePurchaseMessage(){
$('.itemClass').click(function(){
    var itemsPrice = $('.priceClass', this).text();
    var itemsQuantity = $('.quantityClass', this).text();
    var moneyDeposited = $('#totalForItem').val();
    var moneyString  = (parseFloat(itemsPrice) - parseFloat(moneyDeposited)).toFixed(2);

    if(parseInt(itemsQuantity) <= 0){
        $('#purchaseMessage').val('SOLD OUT!');
    }
    else if(parseFloat(itemsPrice) > parseFloat(moneyDeposited)){
        $('#purchaseMessage').val('Please insert' + '$' + moneyString);
    }
    else{
        $('#purchaseMessage').val('Purchase item when ready!');
    }
});
};

function makeChange(){
$('#makeChange').click(function(){
    $('#purchaseMessage').val("0.00");
    $('#changeQuarters').val('Q');
    $('#changeDimes').val('D');
    $('#changeNickels').val('N');
    $('#changePennies').val('P');
});
};