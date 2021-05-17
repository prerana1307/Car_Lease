function filterClicked(filter)
{     
    var selectedFilter = filter!== undefined ? filter.innerText : "";
    getCars(selectedFilter);
    
}

function getCars(selectedFilter)
{
    var container = $('#car-List');
var parameters = {
        sc_itemid: container.parent().data('context')
    };
  	    var renderingContext = JSON.stringify($.param(parameters))    
    
 var filter = 
      $.ajax({
        url: '/api/Cars/GetCars',
        type: "POST",
        context: this,
        data: { currentSite: renderingContext, filterName: selectedFilter },
        success: function (data) {        
        container.replaceWith(data);
       
        },
        error: function (data) {
        console.log("error", data);
        }
      });
}
