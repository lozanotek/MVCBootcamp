var _basePath = "http://localhost:32778/";
var _routeTemplates = {
  "Home": {
    "Index": "http://localhost:32778/{controller}/{action}/{id}"
  }
};
JsonRoutes = {};

JsonRoutes.urlFor = function(action, controller, values) {
    values = values || {};

    if (typeof (_routeTemplates[controller]) == 'undefined' || 
        typeof (_routeTemplates[controller][action]) == 'undefined') {
        
        return null;
    }

    var template = _routeTemplates[controller][action];
    var tokens = template.match(/{[^}]+}/g);
    if (!tokens) { return template; }
    var url = template;
    
    for (var idx = 0; idx < tokens.length; idx++) {
        var token = tokens[idx];
        var name = token.substring(1, token.length - 1);

        var value = null;

        if (name == 'controller') { value = controller; }
        else if (name == 'action') { value = action; }
        else if (typeof (values[name]) != 'undefined') { value = values[name]; }

        if (value != null) {
            url = url.replace(token, value);
        }
    }
    return url;
};
