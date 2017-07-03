$(document).ready(function(){
    
    loadTheItems();

    itemTotals();



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
$('#purchaseButton').click(function(){
        makePurchase();
});
$('.itemClass').click(function(){
    makePurchaseMessage();
});

   $('#makeChange').click(function(){
    makeChange();
   });

});

function loadTheItems(){
    
    
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function(itemArray){
            $.each(itemArray, function(index, item){
                
                var id = item.id;
                
                var populate = $('#item' + id);

                  var  innerText = '<h3 id="name' + id + '">'+item.name +'</h3>';
                    innerText += '<p id="price' + id + '">' + '$'+ item.price +'</p>';
                    innerText += '<p id="quantity' + id + '">'+ 'Quantity: '+ item.quantity +'</p>';
                    innerText += '<p id ="id' + id + '">' + item.id + '</p>';
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

function makePurchase(){
    // var newID = $(this).find('.idClass').text().substring(2,3);
    var newID = $('#itemsID').val();
        
        var itemsPrice = $('.priceClass');
        var moneyDeposited = $('#totalForItem').val();

        // if($('#itemsID').val < 1 || $('#itemsID').val > 9) {
        //     $('#purchaseMessage').val('Please select an item...')
        //     makePurchase();
        // }

        if(isNaN(moneyDeposited)  || isNaN(newID) || moneyDeposited == ""  || moneyDeposited == 0|| newID == "" )
        {
            $('#purchaseMessage').val('Invalid choice ');
        }
        else{
        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/money/'+  moneyDeposited + '/item/' + newID,
            success: function(data){
                
                var quarters = (data.quarters)* .25;
                var dimes = (data.dimes)* .10;
                var nickels = (data.nickels)* .05;
                var pennies = (data.pennies)* .01;
                $('#itemBox').val((quarters+dimes+nickels+pennies).toFixed(2));
                    $('#purchaseMessage').val("Thank You!");
                    // $('#itemChange').val((quarters,dimes,nickels).toFixed(2));
                          var changeBack = '<p>'+ 'Quarters:' + data.quarters + '</p>';
                           changeBack += '<p>'+ 'Dimes:' + data.dimes + '</p>';
                           changeBack+= '<p>'+ 'Nickels:' + data.nickels + '</p>';
                        $('#itemChange').html(changeBack);
                                         loadTheItems();               
                        $("#totalForItem").val(0);    
            },

        error: function(request, status, error ){
            var errors = JSON.parse(request.responseText);
            $('#purchaseMessage').val(errors.message);
        }
    });
        }
};
function makeChange(){
$('#itemChange').html('');
$('#itemBox').val('');
$('#totalForItem').val('');
$('#purchaseMessage').val('');
$('#itemsCost').val('');
$('#itemsID').val('');
};

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
     var id = $(this).find('#id1').text();
     $('#itemsID').val(id);
    //  var quantity = $(this).find('#quantity1').text();
    //  if(('#quantity1').text()<= 0)
    //  {
    //      $('#purchaseMessage').val('Item out of stock');
    //  }
   }),
$('#item2').on('click', function(){
     var price = $(this).find('#price2').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id2').text();
     $('#itemsID').val(id);
   }),
$('#item3').on('click', function(){
     var price = $(this).find('#price3').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id3').text();
     $('#itemsID').val(id);
   }),
$('#item4').on('click', function(){
     var price = $(this).find('#price4').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id4').text();
     $('#itemsID').val(id);
   }),
$('#item5').on('click', function(){
     var price = $(this).find('#price5').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id5').text();
     $('#itemsID').val(id);
   }),
$('#item6').on('click', function(){
     var price = $(this).find('#price6').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id6').text();
     $('#itemsID').val(id);
   }),
$('#item7').on('click', function(){
     var price = $(this).find('#price7').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id7').text();
     $('#itemsID').val(id);
   }),
$('#item8').on('click', function(){
     var price = $(this).find('#price8').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id8').text();
     $('#itemsID').val(id);
   }),
$('#item9').on('click', function(){
     var price = $(this).find('#price9').text();
     $('#itemsCost').val(price);
     var id = $(this).find('#id9').text();
     $('#itemsID').val(id);
   });
};



function makePurchaseMessage(){
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
};

