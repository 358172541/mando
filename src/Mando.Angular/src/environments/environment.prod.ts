import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
    production: true,
    application: {
        baseUrl,
        name: 'Mando',
        logoUrl: '',
    },
    oAuthConfig: {
        issuer: 'https://localhost:44314',
        redirectUri: baseUrl,
        clientId: 'Mando_App',
        responseType: 'code',
        scope: 'offline_access Mando',
        requireHttps: true
    },
    apis: {
        default: {
            url: 'https://localhost:44314',
            rootNamespace: 'Mando',
        },
    },
} as Environment;
