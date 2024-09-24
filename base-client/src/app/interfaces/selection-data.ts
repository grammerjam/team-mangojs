export interface SelectionData {
  id: string,
  title: string,
  year: number,
  category: string,
  rating: string,
  isBookmarked: boolean,
  isTrending: boolean,
  thumbnail: ThumbnailData,
}

export interface ThumbnailData {
  trending?: TrendingData,
  regular: RegularData,
}

export interface TrendingData {
  small: string,
  large: string
}

export interface RegularData {
  small: string,
  medium: string,
  large: string,
}