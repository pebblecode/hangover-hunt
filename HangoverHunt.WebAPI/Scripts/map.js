function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(-34.397, 150.644),
        zoom: 8,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"),
            mapOptions);
}

var geocoder = new google.maps.Geocoder();
var map, lat, lng;

$(function () {

    initialize();

    $("#location").autocomplete({

        source: function (request, response) {

            if (geocoder == null) {
                geocoder = new google.maps.Geocoder();
            }
            geocoder.geocode({ 'address': request.term }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {

                    var searchLoc = results[0].geometry.location;
                    lat = results[0].geometry.location.lat();
                    lng = results[0].geometry.location.lng();
                    var latlng = new google.maps.LatLng(lat, lng);
                    var bounds = results[0].geometry.bounds;

                    geocoder.geocode({ 'latLng': latlng }, function (results1, status1) {
                        if (status1 == google.maps.GeocoderStatus.OK) {
                            if (results1[1]) {
                                response($.map(results1, function (loc) {
                                    return {
                                        label: loc.formatted_address,
                                        value: loc.formatted_address,
                                        bounds: loc.geometry.bounds
                                    }
                                }));
                            }
                        }
                    });
                }
            });
        },
        select: function (event, ui) {
            var pos = ui.item.position;
            var lct = ui.item.locType;
            var bounds = ui.item.bounds;

            $('#geo-location-lat').val(lat);
            $('#geo-location-lng').val(lng);

//            if (bounds) {
//                map.setCenter(lat, lng);
//            }         
        }
    });
}); 