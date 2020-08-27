"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ServiceProxyModule = void 0;
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var abpHttpInterceptor_1 = require("@abp/abpHttpInterceptor");
var ApiServiceProxies = require("@shared/service-proxies/service-proxies");
var ServiceProxyModule = /** @class */ (function () {
    function ServiceProxyModule() {
    }
    ServiceProxyModule = __decorate([
        core_1.NgModule({
            providers: [
                ApiServiceProxies.RoleServiceProxy,
                ApiServiceProxies.SessionServiceProxy,
                ApiServiceProxies.TenantServiceProxy,
                ApiServiceProxies.UserServiceProxy,
                ApiServiceProxies.TokenAuthServiceProxy,
                ApiServiceProxies.AccountServiceProxy,
                ApiServiceProxies.ConfigurationServiceProxy,
                ApiServiceProxies.TenantRegistrationServiceProxy,
                ApiServiceProxies.BookServiceProxy,
                { provide: http_1.HTTP_INTERCEPTORS, useClass: abpHttpInterceptor_1.AbpHttpInterceptor, multi: true },
            ]
        })
    ], ServiceProxyModule);
    return ServiceProxyModule;
}());
exports.ServiceProxyModule = ServiceProxyModule;
