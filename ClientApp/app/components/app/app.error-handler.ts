import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastyService } from "ng2-toasty";

export class AppErrorHandler implements ErrorHandler {
    constructor(
        @Inject(NgZone) private _ngZone: NgZone,
        @Inject(ToastyService) private _toastyService: ToastyService) {
    }

    handleError(error:any): void {
        this._ngZone.run(()=> {
            this._toastyService.error({
                title: "Error",
                msg: "An unexpected error happened",
                theme: "bootstrap",
                showClose: true,
                timeout: 5000,
            });
        })
    }
}

