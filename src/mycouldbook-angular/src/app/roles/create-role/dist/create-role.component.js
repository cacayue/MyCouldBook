"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.CreateRoleComponent = void 0;
var core_1 = require("@angular/core");
var service_proxies_1 = require("@shared/service-proxies/service-proxies");
var component_base_1 = require("@shared/component-base");
var CreateRoleComponent = /** @class */ (function (_super) {
    __extends(CreateRoleComponent, _super);
    function CreateRoleComponent(injector, _roleService) {
        var _this = _super.call(this, injector) || this;
        _this._roleService = _roleService;
        _this.permissions = null;
        _this.role = new service_proxies_1.CreateRoleDto();
        _this.permissionList = [];
        return _this;
    }
    CreateRoleComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._roleService
            .getAllPermissions()
            .subscribe(function (permissions) {
            _this.permissions = permissions;
            _this.permissions.items.forEach(function (item) {
                _this.permissionList.push({
                    label: item.displayName,
                    value: item.name,
                    checked: true
                });
            });
        });
    };
    CreateRoleComponent.prototype.save = function () {
        var _this = this;
        this.saving = true;
        var tmpPermissions = [];
        this.permissionList.forEach(function (item) {
            if (item.checked) {
                tmpPermissions.push(item.value);
            }
        });
        this.role.permissions = tmpPermissions;
        this._roleService
            .create(this.role)["finally"](function () {
            _this.saving = false;
        })
            .subscribe(function () {
            _this.notify.info(_this.l('SavedSuccessfully'));
            _this.success();
        });
    };
    CreateRoleComponent = __decorate([
        core_1.Component({
            selector: 'app-create-role',
            templateUrl: './create-role.component.html',
            styles: []
        })
    ], CreateRoleComponent);
    return CreateRoleComponent;
}(component_base_1.ModalComponentBase));
exports.CreateRoleComponent = CreateRoleComponent;
