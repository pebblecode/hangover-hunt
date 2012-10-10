function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(-34.397, 150.644),
        zoom: 8,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map_canvas"),
            mapOptions);
}

var geocoder = new google.maps.Geocoder();
var map;

$(function () {

    initialize();

    var lat, lng, latlng;

    $("#location").autocomplete({

        source: function (request, response) {

            if (geocoder == null) {
                geocoder = new google.maps.Geocoder();
            }
            geocoder.geocode({ 'address': request.term }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {

                    lat = results[0].geometry.location.lat();
                    lng = results[0].geometry.location.lng();
                    latlng = new google.maps.LatLng(lat, lng);                 

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
            $('#geo-location-lat').val(lat);
            $('#geo-location-lng').val(lng);

            map.setCenter(latlng);
            var pinMarker = new google.maps.Marker({
                position: latlng,
                map: map
            }); 

            console.log('Map centered and pinned!');
            console.log(latlng);            
        }
    });
}); 