import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import * as Sentry from '@sentry/browser';

export class AppErrorHandler implements ErrorHandler {
    // @Inject() is because AppErrorHandler is instantiating before ToastyModule
    // in app module. And here we don't have ToastyService but we need it, So,
    constructor(
        private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService
    ) {
    }

    handleError(error: any): void {
        if (!isDevMode()) {
            Sentry.captureException(error.originalError || error);
        } else {
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
}
