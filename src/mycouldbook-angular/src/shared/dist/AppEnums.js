"use strict";
exports.__esModule = true;
exports.AppTenantAvailabilityState = void 0;
var service_proxies_1 = require("@shared/service-proxies/service-proxies");
var AppTenantAvailabilityState = /** @class */ (function () {
    function AppTenantAvailabilityState() {
    }
    AppTenantAvailabilityState.Available = service_proxies_1.TenantAvailabilityState._1;
    AppTenantAvailabilityState.InActive = service_proxies_1.TenantAvailabilityState._2;
    AppTenantAvailabilityState.NotFound = service_proxies_1.TenantAvailabilityState._3;
    return AppTenantAvailabilityState;
}());
exports.AppTenantAvailabilityState = AppTenantAvailabilityState;
