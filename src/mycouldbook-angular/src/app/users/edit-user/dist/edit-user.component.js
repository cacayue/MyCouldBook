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
exports.EditUserComponent = void 0;
var core_1 = require("@angular/core");
var component_base_1 = require("@shared/component-base");
var EditUserComponent = /** @class */ (function (_super) {
    __extends(EditUserComponent, _super);
    function EditUserComponent(injector, _userService) {
        var _this = _super.call(this, injector) || this;
        _this._userService = _userService;
        _this.user = null;
        _this.roles = null;
        _this.roleList = [];
        return _this;
    }
    EditUserComponent.prototype.ngOnInit = function () {
        this.fetchData();
    };
    EditUserComponent.prototype.fetchData = function () {
        var _this = this;
        this._userService.getRoles().subscribe(function (result) {
            _this.roles = result.items;
            _this._userService.get(_this.id).subscribe(function (result) {
                _this.user = result;
                _this.roles.forEach(function (item) {
                    _this.roleList.push({
                        label: item.displayName,
                        value: item.name,
                        checked: _this.userInRole(item, _this.user)
                    });
                });
            });
        });
    };
    EditUserComponent.prototype.userInRole = function (role, user) {
        return user.roleNames.indexOf(role.normalizedName) !== -1;
    };
    EditUserComponent.prototype.save = function () {
        var _this = this;
        var tmpRoleNames = [];
        this.roleList.forEach(function (item) {
            if (item.checked) {
                tmpRoleNames.push(item.value);
            }
        });
        this.user.roleNames = tmpRoleNames;
        this._userService
            .update(this.user)["finally"](function () {
            _this.saving = false;
        })
            .subscribe(function () {
            _this.notify.info(_this.l('SavedSuccessfully'));
            _this.success();
        });
    };
    __decorate([
        core_1.Input()
    ], EditUserComponent.prototype, "id");
    EditUserComponent = __decorate([
        core_1.Component({
            selector: 'app-edit-user',
            templateUrl: './edit-user.component.html',
            styles: []
        })
    ], EditUserComponent);
    return EditUserComponent;
}(component_base_1.ModalComponentBase));
exports.EditUserComponent = EditUserComponent;
