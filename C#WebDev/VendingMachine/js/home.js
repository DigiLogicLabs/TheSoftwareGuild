$(document).ready(function(){
    loadTheItems();
    addMoney();

    $('#makePurchaseButton').click(function (event) {
        console.log("Total: ", total);
        console.log ("Selected Item Id: ", itemsId);

        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/money/'+ total + '/item/' +itemsId,
            success: function(change){
                $('#purchaseMessage').text("Thank You!");

                total = change.quarter * .25 +
                change.dime * .10 +
                change.nickel *.05 +
                change.penny * .01;
            $('#total').html(total);

            $('#changeButton').click(function(event){
                $('#changeQuarters').text("Quarters: " + change.quarter);
               $('#changeDimes').text("Dimes: " + change.dime);
               $('#changeNickels').text("Nickels: "+ change.nickel );
               $('#changePennies').text("Pennies: " + change.penny);

               total=0;
               $('#total').html(total);

               loadTheItems();

            });
            console.log("success", change);

        },
        error: function(response){
            $('#purchaseMessage').empty();
            $('#purchaseMessage').alert("an error has occured")
            console.log("error", response);
        }
        })
    })
});

var itemsId = 0;


var itemsCost = ('#itemsCost');


var dollar = 1.00;
var quarter = 0.25;
var dime = 0.10;
var nickel = 0.05;
var penny = 0.01;
var moneyIn = 0.00; 
var total = 0.00;

function amountBoxChange(){
$('.amountBox').on('change', function(){
    var value = $(this).val();
    var price 
})
};

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
function addMoney(){
        $('#addDollarButton').on('click', function (){
            moneyIn += dollar;
            ('#total').html(moneyIn);
        }),
        $('#addQuarterButton').on('click', function (){
            moneyIn += quarter;
            ('#total').html(moneyIn);
        }),
        $('#addDimeButton').on('click', function (){
            moneyIn += dime;
            ('#total').html(moneyIn);
        }),
        $('#addNickelButton').on('click', function (){
            moneyIn += nickel;
            ('#total').html(moneyIn);
        })
};


function itemTotals(){
   $('#item1').on('click', function(){
       ('#totalForItem').val('#price1');
   }),
   $('#item2').on('click', function(){
       ('#totalForItem').val('#price2');
   }),
   $('#item3').on('click', function(){
       ('#totalForItem').val('#price3');
   }),
   $('#item4').on('click', function(){
       ('#totalForItem').val('#price4');
   }),
   $('#item5').on('click', function(){
       ('#totalForItem').val('#price5');
   }),
   $('#item6').on('click', function(){
       ('#totalForItem').val('#price6');
   }),
   $('#item7').on('click', function(){
       ('#totalForItem').val('#price7');
   }),
   $('#item8').on('click', function(){
       ('#totalForItem').val('#price8');
   }),
   $('#item9').on('click', function(){
       ('#totalForItem').val('#price9');
   })
};
