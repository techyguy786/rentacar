import { ErrorHandler, Inject, NgZone } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

export class AppErrorHandler implements ErrorHandler {
    // @Inject() is because AppErrorHandler is instantiating before ToastyModule
    // in app module. And here we don't have ToastyService but we need it, So,
    constructor(
        private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService
    ) {
    }

    handleError(error: any): void {
        this.ngZone.run(() => {
            this.toastyService.error({
                title: 'Error',
                msg: 'An Unexpected Error Happened',
                theme: 'default',
                showClose: true,
                timeout: 5000
            });
        });
    }
}
