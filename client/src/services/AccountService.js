import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Favorite } from '../models/Favorite.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getFavorites() {
    const res = await api.get("/account/favorites")

    logger.log('getting favorites', res.data)
    AppState.myFavoritePhotos = res.data.map((favorite) => new Favorite(favorite))
  }
}

export const accountService = new AccountService()
