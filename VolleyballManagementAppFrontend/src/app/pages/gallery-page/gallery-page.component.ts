import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-gallery-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './gallery-page.component.html',
  styleUrls: ['./gallery-page.component.scss'],
})
export class GalleryPageComponent {
  imageUrls: string[] = [
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_175955_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_232549_simi.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_133920_david.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_145943_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_185355_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_172736_kendras.jpg',
    'https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg',
    'https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_135402_kendras.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_105829_adrian.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_151826_adrian.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_180535_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_183252_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_190934_gery.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_141954_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_141708_david.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_145023_david.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_164642_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_170030_akos.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_172919_barczy.jpg',
    'https://spot.sch.bme.hu/photos/2025/20250426_muegyetemi_roplabda/2048/20250426_173236_barczy.jpg',
  ];
}
