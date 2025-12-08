import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators'

export const authConfigHttpLoaderFactory = (httpClient: HttpClient) => {
  const config$ = httpClient.get<any>('/api/.auth/config').pipe(
    map((customConfig: any) => {
      return {
        authority: customConfig.authority,
        clientId: customConfig.clientId,
        scope: customConfig.scope
      }
    })
  )
}